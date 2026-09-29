using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MB01.A1_2_5
{
    public partial class BinaryCalculator : Form
    {
        /*
         * Field (Feld / Klassenvariable)
         *
         * Verhindert rekursive TextChanged-Events:
         *
         * Dezimal -> Binär -> TextChanged -> Dezimal -> ...
         */
        private bool _isUpdating;


        /*
         * Während des Programmstarts werden Bit-Änderungen
         * noch NICHT animiert.
         *
         * Erst wenn die Oberfläche fertig aufgebaut ist,
         * wird die Animation aktiviert.
         */
        private bool _animateBitChanges;


        /*
         * Arrays (Felder)
         *
         * Fassen die vier zusammengehörenden TextBox-Objects
         * (Objekte) zusammen.
         */
        private TextBox[] _decimalIpBoxes = Array.Empty<TextBox>();
        private TextBox[] _binaryIpBoxes = Array.Empty<TextBox>();
        private TextBox[] _maskBoxes = Array.Empty<TextBox>();


        /*
         * 5 Zeilen × 32 Bits.
         *
         * Zeile 0 = IP
         * Zeile 1 = Subnet Mask
         * Zeile 2 = Network
         * Zeile 3 = Broadcast
         * Zeile 4 = Wildcard
         */
        private readonly Label[,] _bitCells =
            new Label[5, 32];


        /*
         * Rechte Spalte der Tabelle:
         * dotted-decimal Darstellung.
         */
        private readonly Label[] _tableValueLabels =
            new Label[5];


        /*
         * Speichert aktuell pulsierende Zellen und die Farbe,
         * zu der sie nach dem kurzen Aufblitzen zurückkehren.
         */
        private readonly Dictionary<Label, Color> _changedCells =
            new Dictionary<Label, Color>();


        /*
         * Timer (Zeitgeber-Control)
         *
         * Nach kurzer Zeit werden hervorgehobene Bits
         * wieder normal dargestellt.
         */
        private readonly System.Windows.Forms.Timer _bitPulseTimer =
            new System.Windows.Forms.Timer();


        /*
         * Farben der Bit-Darstellung.
         */
        private static readonly Color NetworkBitColor =
            Color.FromArgb(226, 238, 250);

        private static readonly Color HostBitColor =
            Color.FromArgb(232, 246, 235);

        private static readonly Color PulseBitColor =
            Color.FromArgb(255, 239, 153);


        /*
         * Constructor (Konstruktor)
         */
        public BinaryCalculator()
        {
            InitializeComponent();


            /*
             * Auch die Form selbst doppelt puffern.
             */
            DoubleBuffered = true;

            SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint,
                true
            );

            UpdateStyles();


            /*
             * Timer dem Komponenten-Container hinzufügen.
             *
             * Dadurch wird er beim Schliessen der Form
             * automatisch disposed.
             */
            components?.Add(_bitPulseTimer);

            _bitPulseTimer.Interval = 160;
            _bitPulseTimer.Tick += BitPulseTimer_Tick;


            /*
             * TextBoxen zu Arrays zusammenfassen.
             */
            _decimalIpBoxes =
            [
                TxtDecimalOctet1,
                TxtDecimalOctet2,
                TxtDecimalOctet3,
                TxtDecimalOctet4
            ];

            _binaryIpBoxes =
            [
                TxtOctet1,
                TxtOctet2,
                TxtOctet3,
                TxtOctet4
            ];

            _maskBoxes =
            [
                TxtMaskOctet1,
                TxtMaskOctet2,
                TxtMaskOctet3,
                TxtMaskOctet4
            ];


            /*
             * Wichtig gegen das Aufblitzen beim Start:
             *
             * Tabelle bleibt unsichtbar, bis
             *
             * - alle Label-Objects erzeugt sind
             * - Startwerte geladen sind
             * - erste Berechnung abgeschlossen ist
             */
            TblBinaryMap.Visible = false;

            BuildBinaryMap();

            LoadAddress(
                192,
                168,
                1,
                10,
                24
            );

            TblBinaryMap.Visible = true;
            TblBinaryMap.Invalidate(true);


            /*
             * Erst AB JETZT dürfen Änderungen animiert werden.
             */
            _animateBitChanges = true;
        }


        // =========================================================
        // IPv4 DEZIMAL -> BINÄR
        // =========================================================

        private void TxtIpDecimal_TextChanged(
            object sender,
            EventArgs e)
        {
            if (_isUpdating)
            {
                return;
            }


            /*
             * sender = Object (Objekt), das das Event ausgelöst hat.
             */
            if (sender is not TextBox currentTextBox)
            {
                return;
            }


            /*
             * Position des veränderten Oktetts bestimmen.
             */
            int index =
                Array.IndexOf(
                    _decimalIpBoxes,
                    currentTextBox
                );


            if (index < 0)
            {
                return;
            }


            /*
             * Während der Eingabe darf das Feld kurz leer sein.
             */
            if (currentTextBox.Text == "")
            {
                ErrInput.SetError(
                    currentTextBox,
                    ""
                );


                _isUpdating = true;

                try
                {
                    _binaryIpBoxes[index].Text = "";
                }
                finally
                {
                    _isUpdating = false;
                }


                InvalidateCalculation(
                    "IPv4-Adresse ist noch unvollständig."
                );

                return;
            }


            /*
             * byte.TryParse()
             *
             * byte = Datentyp 0 bis 255.
             *
             * Perfekt für ein IPv4-Oktett.
             */
            if (!byte.TryParse(
                    currentTextBox.Text,
                    out byte decimalValue))
            {
                ErrInput.SetError(
                    currentTextBox,
                    "IPv4-Oktett: nur Werte von 0 bis 255."
                );


                InvalidateCalculation(
                    "Ungültiges IPv4-Oktett."
                );

                return;
            }


            ErrInput.SetError(
                currentTextBox,
                ""
            );


            /*
             * Dezimal -> Binär
             *
             * 192
             * ↓
             * 11000000
             */
            string binaryValue =
                Convert
                    .ToString(decimalValue, 2)
                    .PadLeft(8, '0');


            _isUpdating = true;

            try
            {
                _binaryIpBoxes[index].Text =
                    binaryValue;
            }
            finally
            {
                _isUpdating = false;
            }


            RecalculateSubnet();
        }


        // =========================================================
        // IPv4 BINÄR -> DEZIMAL
        // =========================================================

        private void TxtIpBinary_TextChanged(
            object sender,
            EventArgs e)
        {
            if (_isUpdating)
            {
                return;
            }


            if (sender is not TextBox currentTextBox)
            {
                return;
            }


            int index =
                Array.IndexOf(
                    _binaryIpBoxes,
                    currentTextBox
                );


            if (index < 0)
            {
                return;
            }


            if (currentTextBox.Text == "")
            {
                ErrInput.SetError(
                    currentTextBox,
                    ""
                );


                _isUpdating = true;

                try
                {
                    _decimalIpBoxes[index].Text = "";
                }
                finally
                {
                    _isUpdating = false;
                }


                InvalidateCalculation(
                    "IPv4-Adresse ist noch unvollständig."
                );

                return;
            }


            /*
             * Binäre Eingabe validieren.
             */
            if (!IsBinary(currentTextBox.Text))
            {
                ErrInput.SetError(
                    currentTextBox,
                    "Binär sind nur die Zeichen 0 und 1 erlaubt."
                );


                InvalidateCalculation(
                    "Ungültige Binäreingabe."
                );

                return;
            }


            ErrInput.SetError(
                currentTextBox,
                ""
            );


            /*
             * Binär -> Dezimal
             */
            int decimalValue =
                Convert.ToInt32(
                    currentTextBox.Text,
                    2
                );


            _isUpdating = true;

            try
            {
                _decimalIpBoxes[index].Text =
                    decimalValue.ToString();
            }
            finally
            {
                _isUpdating = false;
            }


            RecalculateSubnet();
        }


        // =========================================================
        // CIDR -> SUBNET MASK
        // =========================================================

        private void NumCidr_ValueChanged(
            object sender,
            EventArgs e)
        {
            if (_isUpdating)
            {
                return;
            }


            int prefix =
                (int)NumCidr.Value;


            ApplyPrefixToMask(prefix);

            RecalculateSubnet();
        }


        // =========================================================
        // SUBNET MASK -> CIDR
        // =========================================================

        private void TxtMask_TextChanged(
            object sender,
            EventArgs e)
        {
            if (_isUpdating)
            {
                return;
            }


            if (sender is not TextBox currentTextBox)
            {
                return;
            }


            if (currentTextBox.Text == "")
            {
                ErrInput.SetError(
                    currentTextBox,
                    ""
                );


                InvalidateCalculation(
                    "Subnetzmaske ist noch unvollständig."
                );

                return;
            }


            /*
             * Jedes Masken-Oktett muss 0 bis 255 sein.
             */
            if (!byte.TryParse(
                    currentTextBox.Text,
                    out _))
            {
                ErrInput.SetError(
                    currentTextBox,
                    "Masken-Oktett: nur Werte von 0 bis 255."
                );


                InvalidateCalculation(
                    "Ungültige Subnetzmaske."
                );

                return;
            }


            ErrInput.SetError(
                currentTextBox,
                ""
            );


            if (!TryReadMask(
                    out byte[] maskOctets))
            {
                return;
            }


            /*
             * Prüfen:
             *
             * Eine echte Subnetzmaske muss aus
             * zusammenhängenden 1-Bits bestehen.
             */
            if (!TrySubnetMaskToPrefix(
                    maskOctets,
                    out int prefix))
            {
                ErrInput.SetError(
                    currentTextBox,
                    "Ungültige Subnetzmaske: 1-Bits müssen zusammenhängend sein."
                );


                InvalidateCalculation(
                    "Die Subnetzmaske ist nicht CIDR-konform."
                );

                return;
            }


            /*
             * Alle Maskenfehler entfernen.
             */
            foreach (TextBox box in _maskBoxes)
            {
                ErrInput.SetError(
                    box,
                    ""
                );
            }


            /*
             * CIDR-Control mit der Maske synchronisieren.
             */
            _isUpdating = true;

            try
            {
                NumCidr.Value = prefix;
            }
            finally
            {
                _isUpdating = false;
            }


            uint mask =
                OctetsToUInt32(maskOctets);


            UpdateMaskDisplay(
                mask,
                prefix
            );


            RecalculateSubnet();
        }


        // =========================================================
        // HAUPTBERECHNUNG
        // =========================================================

        private void RecalculateSubnet()
        {
            if (!TryReadIp(
                    out byte[] ipOctets))
            {
                InvalidateCalculation(
                    "IPv4-Adresse ist ungültig oder unvollständig."
                );

                return;
            }


            if (!TryReadMask(
                    out byte[] maskOctets))
            {
                InvalidateCalculation(
                    "Subnetzmaske ist ungültig oder unvollständig."
                );

                return;
            }


            if (!TrySubnetMaskToPrefix(
                    maskOctets,
                    out int prefix))
            {
                InvalidateCalculation(
                    "Subnetzmaske ist nicht CIDR-konform."
                );

                return;
            }


            /*
             * uint
             *
             * unsigned 32-bit integer
             *
             * Eine IPv4-Adresse besitzt genau 32 Bit.
             */
            uint ip =
                OctetsToUInt32(ipOctets);

            uint mask =
                OctetsToUInt32(maskOctets);


            /*
             * Bitwise AND (bitweises UND)
             *
             * IP & MASK = NETWORK
             */
            uint network =
                ip & mask;


            /*
             * ~ = bitweise Negation
             *
             * NOT Subnet Mask = Wildcard
             */
            uint wildcard =
                ~mask;


            /*
             * Bitwise OR
             *
             * NETWORK | WILDCARD = BROADCAST
             */
            uint broadcast =
                network | wildcard;


            int hostBits =
                32 - prefix;


            /*
             * ulong deshalb, weil /0 insgesamt
             *
             * 2^32 = 4'294'967'296
             *
             * Adressen besitzt.
             */
            ulong totalAddresses =
                1UL << hostBits;


            ulong usableHosts;


            /*
             * /31:
             * RFC3021 Point-to-Point
             *
             * /32:
             * einzelne Hostroute
             */
            if (prefix == 32)
            {
                usableHosts = 1;
            }
            else if (prefix == 31)
            {
                usableHosts = 2;
            }
            else
            {
                usableHosts =
                    totalAddresses - 2;
            }


            uint firstHost;
            uint lastHost;


            if (prefix == 32)
            {
                firstHost = ip;
                lastHost = ip;
            }
            else if (prefix == 31)
            {
                firstHost = network;
                lastHost = broadcast;
            }
            else
            {
                firstHost =
                    network + 1;

                lastHost =
                    broadcast - 1;
            }


            /*
             * Ergebnisse in UI-Properties schreiben.
             */
            LblCurrentIpValue.Text =
                $"{ToIpString(ip)} /{prefix}";


            LblNetworkValue.Text =
                ToIpString(network);


            LblBroadcastValue.Text =
                ToIpString(broadcast);


            LblFirstHostValue.Text =
                ToIpString(firstHost);


            LblLastHostValue.Text =
                ToIpString(lastHost);


            LblWildcardValue.Text =
                ToIpString(wildcard);


            LblTotalAddressesValue.Text =
                totalAddresses.ToString("N0");


            LblUsableHostsValue.Text =
                usableHosts.ToString("N0");


            LblNetworkBitsValue.Text =
                $"{prefix} Network Bits / {hostBits} Host Bits";


            LblAddressTypeValue.Text =
                GetAddressType(ip);


            UpdateMaskDisplay(
                mask,
                prefix
            );


            UpdateBinaryMap(
                ip,
                mask,
                network,
                broadcast,
                wildcard,
                prefix
            );


            SetStatus(
                $"Bereit – {ToIpString(ip)}/{prefix} wurde berechnet.",
                false
            );
        }


        // =========================================================
        // VALIDIERUNG
        // =========================================================

        private bool IsBinary(
            string text)
        {
            foreach (char character in text)
            {
                if (character != '0' &&
                    character != '1')
                {
                    return false;
                }
            }


            return true;
        }


        private bool TryReadIp(
            out byte[] octets)
        {
            octets =
                new byte[4];


            for (int i = 0;
                 i < _decimalIpBoxes.Length;
                 i++)
            {
                if (!byte.TryParse(
                        _decimalIpBoxes[i].Text,
                        out octets[i]))
                {
                    return false;
                }
            }


            return true;
        }


        private bool TryReadMask(
            out byte[] octets)
        {
            octets =
                new byte[4];


            for (int i = 0;
                 i < _maskBoxes.Length;
                 i++)
            {
                if (!byte.TryParse(
                        _maskBoxes[i].Text,
                        out octets[i]))
                {
                    return false;
                }
            }


            return true;
        }


        private bool TrySubnetMaskToPrefix(
            byte[] maskOctets,
            out int prefix)
        {
            uint mask =
                OctetsToUInt32(maskOctets);


            prefix = 0;

            bool zeroSeen = false;


            /*
             * Von Bit 31 nach Bit 0 laufen.
             */
            for (int bit = 31;
                 bit >= 0;
                 bit--)
            {
                bool bitIsOne =
                    (mask &
                     (1u << bit)) != 0;


                if (bitIsOne)
                {
                    /*
                     * Wenn bereits eine 0 gesehen wurde
                     * und danach wieder eine 1 kommt,
                     * ist die Maske ungültig.
                     */
                    if (zeroSeen)
                    {
                        return false;
                    }


                    prefix++;
                }
                else
                {
                    zeroSeen = true;
                }
            }


            return true;
        }


        // =========================================================
        // CIDR / MASK
        // =========================================================

        private void ApplyPrefixToMask(
            int prefix)
        {
            uint mask =
                PrefixToMask(prefix);


            byte[] octets =
                UInt32ToOctets(mask);


            bool oldUpdatingState =
                _isUpdating;


            _isUpdating = true;

            try
            {
                for (int i = 0;
                     i < 4;
                     i++)
                {
                    _maskBoxes[i].Text =
                        octets[i].ToString();
                }
            }
            finally
            {
                _isUpdating =
                    oldUpdatingState;
            }


            UpdateMaskDisplay(
                mask,
                prefix
            );
        }


        private uint PrefixToMask(
            int prefix)
        {
            if (prefix == 0)
            {
                return 0u;
            }


            return uint.MaxValue
                   << (32 - prefix);
        }


        private void UpdateMaskDisplay(
            uint mask,
            int prefix)
        {
            LblMaskBinaryValue.Text =
                $"Binär: {ToBinaryDotted(mask)}";


            LblPrefixInfoValue.Text =
                $"/{prefix} = {prefix} Network Bits / {32 - prefix} Host Bits";
        }


        // =========================================================
        // IPv4 <-> uint
        // =========================================================

        private uint OctetsToUInt32(
            byte[] octets)
        {
            return
                ((uint)octets[0] << 24) |
                ((uint)octets[1] << 16) |
                ((uint)octets[2] << 8) |
                octets[3];
        }


        private byte[] UInt32ToOctets(
            uint value)
        {
            return
            [
                (byte)(value >> 24),
                (byte)(value >> 16),
                (byte)(value >> 8),
                (byte)value
            ];
        }


        private string ToIpString(
            uint value)
        {
            byte[] octets =
                UInt32ToOctets(value);


            return
                $"{octets[0]}.{octets[1]}.{octets[2]}.{octets[3]}";
        }


        private string ToBinaryDotted(
            uint value)
        {
            byte[] octets =
                UInt32ToOctets(value);


            return
                $"{Convert.ToString(octets[0], 2).PadLeft(8, '0')}." +
                $"{Convert.ToString(octets[1], 2).PadLeft(8, '0')}." +
                $"{Convert.ToString(octets[2], 2).PadLeft(8, '0')}." +
                $"{Convert.ToString(octets[3], 2).PadLeft(8, '0')}";
        }


        // =========================================================
        // ADRESSTYP
        // =========================================================

        private string GetAddressType(
            uint ip)
        {
            byte[] o =
                UInt32ToOctets(ip);


            if (ip == 0)
            {
                return "Unspecified (0.0.0.0)";
            }


            if (ip == uint.MaxValue)
            {
                return "Limited Broadcast";
            }


            if (o[0] == 10)
            {
                return "Privat – RFC1918 (10.0.0.0/8)";
            }


            if (o[0] == 172 &&
                o[1] >= 16 &&
                o[1] <= 31)
            {
                return "Privat – RFC1918 (172.16.0.0/12)";
            }


            if (o[0] == 192 &&
                o[1] == 168)
            {
                return "Privat – RFC1918 (192.168.0.0/16)";
            }


            if (o[0] == 127)
            {
                return "Loopback";
            }


            if (o[0] == 169 &&
                o[1] == 254)
            {
                return "Link-Local / APIPA";
            }


            if (o[0] == 100 &&
                o[1] >= 64 &&
                o[1] <= 127)
            {
                return "Carrier-Grade NAT (100.64.0.0/10)";
            }


            if (o[0] >= 224 &&
                o[0] <= 239)
            {
                return "Multicast";
            }


            if (o[0] >= 240)
            {
                return "Reservierter Bereich";
            }


            return "Unicast / kein gängiger Sonderbereich erkannt";
        }


        // =========================================================
        // 32-BIT-TABELLE AUFBAUEN
        // =========================================================

        private void BuildBinaryMap()
        {
            /*
             * SuspendLayout()
             *
             * verhindert, dass nach jedem einzelnen
             * neuen Label-Object das Layout neu berechnet wird.
             */
            TblBinaryMap.SuspendLayout();


            try
            {
                TblBinaryMap.Controls.Clear();


                /*
                 * Header links.
                 */
                AddMapLabel(
                    "WERT",
                    0,
                    0,
                    true
                );


                /*
                 * Bitnummern 31 bis 0.
                 */
                for (int column = 0;
                     column < 32;
                     column++)
                {
                    AddMapLabel(
                        (31 - column).ToString(),
                        column + 1,
                        0,
                        true
                    );
                }


                /*
                 * Header rechts.
                 */
                AddMapLabel(
                    "DEZIMAL",
                    33,
                    0,
                    true
                );


                string[] rowNames =
                [
                    "IP",
                    "SUBNET MASK",
                    "NETWORK",
                    "BROADCAST",
                    "WILDCARD"
                ];


                for (int row = 0;
                     row < rowNames.Length;
                     row++)
                {
                    AddMapLabel(
                        rowNames[row],
                        0,
                        row + 1,
                        true
                    );


                    for (int bit = 0;
                         bit < 32;
                         bit++)
                    {
                        _bitCells[row, bit] =
                            AddMapLabel(
                                "0",
                                bit + 1,
                                row + 1
                            );
                    }


                    _tableValueLabels[row] =
                        AddMapLabel(
                            "0.0.0.0",
                            33,
                            row + 1
                        );
                }
            }
            finally
            {
                /*
                 * Nur einmal am Ende layouten.
                 */
                TblBinaryMap.ResumeLayout(false);
            }
        }


        private Label AddMapLabel(
            string text,
            int column,
            int row,
            bool bold = false)
        {
            /*
             * Label = Class (Klasse)
             *
             * new Label() = neues Object (Objekt / Instanz)
             */
            Label label =
                new Label();


            /*
             * Properties (Eigenschaften)
             */
            label.AutoSize = false;
            label.Text = text;

            label.Dock =
                DockStyle.Fill;

            label.TextAlign =
                ContentAlignment.MiddleCenter;

            label.Margin =
                new Padding(0);


            if (bold)
            {
                label.Font =
                    new Font(
                        label.Font,
                        FontStyle.Bold
                    );
            }


            TblBinaryMap.Controls.Add(
                label,
                column,
                row
            );


            return label;
        }


        // =========================================================
        // 32-BIT-TABELLE LIVE AKTUALISIEREN
        // =========================================================

        private void UpdateBinaryMap(
            uint ip,
            uint mask,
            uint network,
            uint broadcast,
            uint wildcard,
            int prefix)
        {
            uint[] values =
            [
                ip,
                mask,
                network,
                broadcast,
                wildcard
            ];


            bool hasNewPulse = false;


            /*
             * Kein Layout wird verändert:
             * nur Text und Farbe.
             *
             * Deshalb müssen wir hier nicht jedes Mal
             * ein vollständiges Layout neu berechnen.
             */
            for (int row = 0;
                 row < values.Length;
                 row++)
            {
                for (int column = 0;
                     column < 32;
                     column++)
                {
                    int physicalBit =
                        31 - column;


                    bool bitIsOne =
                        (values[row] &
                         (1u << physicalBit)) != 0;


                    Label cell =
                        _bitCells[row, column];


                    string newText =
                        bitIsOne
                            ? "1"
                            : "0";


                    Color normalColor =
                        column < prefix
                            ? NetworkBitColor
                            : HostBitColor;


                    /*
                     * Hat sich dieses Bit tatsächlich geändert?
                     */
                    bool bitChanged =
                        cell.Text != newText;


                    if (bitChanged)
                    {
                        cell.Text =
                            newText;


                        /*
                         * Während des Starts keine Animation.
                         */
                        if (_animateBitChanges)
                        {
                            /*
                             * Speichern, welche Farbe nach
                             * dem Pulse wiederhergestellt wird.
                             */
                            _changedCells[cell] =
                                normalColor;


                            /*
                             * Nur das geänderte Bit aufblitzen lassen.
                             */
                            cell.BackColor =
                                PulseBitColor;


                            hasNewPulse = true;
                        }
                        else
                        {
                            cell.BackColor =
                                normalColor;
                        }
                    }
                    else
                    {
                        /*
                         * Falls die Zelle gerade noch pulsiert
                         * und sich z.B. nur der CIDR-Prefix geändert hat,
                         * muss ihre spätere Zielfarbe aktualisiert werden.
                         */
                        if (_changedCells.ContainsKey(cell))
                        {
                            _changedCells[cell] =
                                normalColor;
                        }
                        else if (cell.BackColor != normalColor)
                        {
                            cell.BackColor =
                                normalColor;
                        }
                    }
                }


                string ipText =
                    ToIpString(values[row]);


                /*
                 * Property nur ändern,
                 * wenn wirklich nötig.
                 */
                if (_tableValueLabels[row].Text != ipText)
                {
                    _tableValueLabels[row].Text =
                        ipText;
                }
            }


            /*
             * Timer nur EINMAL nach dem kompletten Update starten.
             */
            if (hasNewPulse)
            {
                _bitPulseTimer.Stop();
                _bitPulseTimer.Start();
            }


            /*
             * Einmal neu zeichnen.
             */
            TblBinaryMap.Invalidate();
        }


        // =========================================================
        // BIT-PULSE
        // =========================================================

        private void BitPulseTimer_Tick(
            object? sender,
            EventArgs e)
        {
            _bitPulseTimer.Stop();


            /*
             * Alle geänderten Bits zurück auf ihre
             * normale Network-/Host-Farbe setzen.
             */
            foreach (
                KeyValuePair<Label, Color> item
                in _changedCells)
            {
                if (!item.Key.IsDisposed)
                {
                    item.Key.BackColor =
                        item.Value;
                }
            }


            _changedCells.Clear();


            TblBinaryMap.Invalidate();
        }


        private void ClearBinaryMap()
        {
            /*
             * Eventuelle laufende Pulse abbrechen.
             */
            _bitPulseTimer.Stop();
            _changedCells.Clear();


            for (int row = 0;
                 row < 5;
                 row++)
            {
                for (int bit = 0;
                     bit < 32;
                     bit++)
                {
                    _bitCells[row, bit].Text =
                        "·";


                    _bitCells[row, bit].BackColor =
                        SystemColors.Control;
                }


                _tableValueLabels[row].Text =
                    "—";
            }


            TblBinaryMap.Invalidate();
        }


        // =========================================================
        // INVALID STATE
        // =========================================================

        private void InvalidateCalculation(
            string message)
        {
            LblCurrentIpValue.Text =
                "—";


            LblNetworkValue.Text =
                "—";


            LblBroadcastValue.Text =
                "—";


            LblFirstHostValue.Text =
                "—";


            LblLastHostValue.Text =
                "—";


            LblWildcardValue.Text =
                "—";


            LblTotalAddressesValue.Text =
                "—";


            LblUsableHostsValue.Text =
                "—";


            LblNetworkBitsValue.Text =
                "—";


            LblAddressTypeValue.Text =
                "—";


            ClearBinaryMap();


            SetStatus(
                message,
                true
            );
        }


        private void SetStatus(
            string message,
            bool error)
        {
            StsState.Text =
                message;


            StsState.ForeColor =
                error
                    ? Color.Firebrick
                    : Color.DarkGreen;
        }


        // =========================================================
        // BEISPIEL / RESET
        // =========================================================

        private void LoadAddress(
            byte octet1,
            byte octet2,
            byte octet3,
            byte octet4,
            int prefix)
        {
            byte[] values =
            [
                octet1,
                octet2,
                octet3,
                octet4
            ];


            bool oldUpdatingState =
                _isUpdating;


            _isUpdating = true;


            try
            {
                for (int i = 0;
                     i < 4;
                     i++)
                {
                    _decimalIpBoxes[i].Text =
                        values[i].ToString();


                    _binaryIpBoxes[i].Text =
                        Convert
                            .ToString(values[i], 2)
                            .PadLeft(8, '0');
                }


                NumCidr.Value =
                    prefix;


                uint mask =
                    PrefixToMask(prefix);


                byte[] maskOctets =
                    UInt32ToOctets(mask);


                for (int i = 0;
                     i < 4;
                     i++)
                {
                    _maskBoxes[i].Text =
                        maskOctets[i].ToString();
                }


                ErrInput.Clear();
            }
            finally
            {
                _isUpdating =
                    oldUpdatingState;
            }


            RecalculateSubnet();
        }


        private void CmdExample_Click(
            object sender,
            EventArgs e)
        {
            LoadAddress(
                192,
                168,
                1,
                10,
                24
            );
        }


        private void CmdReset_Click(
            object sender,
            EventArgs e)
        {
            LoadAddress(
                0,
                0,
                0,
                0,
                24
            );
        }


        // =========================================================
        // UX
        // =========================================================

        private void Txt_SelectAllOnEnter(
            object sender,
            EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }
    }
}