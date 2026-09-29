using System.Drawing;
using System.Windows.Forms;

namespace MB01.A1_2_5
{
    partial class BinaryCalculator
    {
        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                components != null)
            {
                components.Dispose();
            }


            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components =
                new System.ComponentModel.Container();


            // =====================================================
            // HAUPT-CONTAINER
            // =====================================================

            GrpIp =
                new GroupBox();

            GrpSubnet =
                new GroupBox();

            GrpResults =
                new GroupBox();

            GrpBits =
                new GroupBox();


            // =====================================================
            // IPv4 INPUT
            // =====================================================

            LblDecimalInput =
                new Label();

            LblBinaryInput =
                new Label();


            TxtDecimalOctet1 =
                new TextBox();

            TxtDecimalOctet2 =
                new TextBox();

            TxtDecimalOctet3 =
                new TextBox();

            TxtDecimalOctet4 =
                new TextBox();


            TxtOctet1 =
                new TextBox();

            TxtOctet2 =
                new TextBox();

            TxtOctet3 =
                new TextBox();

            TxtOctet4 =
                new TextBox();


            LblCurrentIpCaption =
                new Label();

            LblCurrentIpValue =
                new Label();

            LblIpHint =
                new Label();


            // =====================================================
            // SUBNET
            // =====================================================

            LblCidr =
                new Label();

            NudCidr =
                new NumericUpDown();

            LblSubnetMask =
                new Label();


            TxtMaskOctet1 =
                new TextBox();

            TxtMaskOctet2 =
                new TextBox();

            TxtMaskOctet3 =
                new TextBox();

            TxtMaskOctet4 =
                new TextBox();


            LblMaskBinaryValue =
                new Label();

            LblPrefixInfoValue =
                new Label();


            // =====================================================
            // RESULTS
            // =====================================================

            LblNetworkCaption =
                new Label();

            LblNetworkValue =
                new Label();


            LblBroadcastCaption =
                new Label();

            LblBroadcastValue =
                new Label();


            LblFirstHostCaption =
                new Label();

            LblFirstHostValue =
                new Label();


            LblLastHostCaption =
                new Label();

            LblLastHostValue =
                new Label();


            LblWildcardCaption =
                new Label();

            LblWildcardValue =
                new Label();


            LblTotalAddressesCaption =
                new Label();

            LblTotalAddressesValue =
                new Label();


            LblUsableHostsCaption =
                new Label();

            LblUsableHostsValue =
                new Label();


            LblNetworkBitsCaption =
                new Label();

            LblNetworkBitsValue =
                new Label();


            LblAddressTypeCaption =
                new Label();

            LblAddressTypeValue =
                new Label();


            CmdExample =
                new Button();

            CmdReset =
                new Button();


            // =====================================================
            // BIT TABLE
            // =====================================================

            TblBinaryMap =
                new DoubleBufferedTableLayoutPanel();


            LblNetworkLegend =
                new Label();

            LblHostLegend =
                new Label();


            // =====================================================
            // COMPONENTS
            // =====================================================

            ErrInput =
                new ErrorProvider(components);


            TipHelp =
                new ToolTip(components);


            StatusMain =
                new StatusStrip();


            StsState =
                new ToolStripStatusLabel();


            ((System.ComponentModel.ISupportInitialize)
                NudCidr).BeginInit();


            ((System.ComponentModel.ISupportInitialize)
                ErrInput).BeginInit();


            GrpIp.SuspendLayout();

            GrpSubnet.SuspendLayout();

            GrpResults.SuspendLayout();

            GrpBits.SuspendLayout();

            StatusMain.SuspendLayout();

            SuspendLayout();


            // =====================================================
            // GROUP: IP
            // =====================================================

            GrpIp.Location =
                new Point(20, 15);

            GrpIp.Name =
                "GrpIp";

            GrpIp.Size =
                new Size(1140, 175);

            GrpIp.TabIndex =
                0;

            GrpIp.TabStop =
                false;

            GrpIp.Text =
                "IPv4-Adresse – bidirektionale Konvertierung";


            // -----------------------------------------------------
            // Decimal caption
            // -----------------------------------------------------

            LblDecimalInput.AutoSize =
                true;

            LblDecimalInput.Location =
                new Point(20, 38);

            LblDecimalInput.Name =
                "LblDecimalInput";

            LblDecimalInput.Text =
                "Dezimal / IPv4";


            // -----------------------------------------------------
            // Binary caption
            // -----------------------------------------------------

            LblBinaryInput.AutoSize =
                true;

            LblBinaryInput.Location =
                new Point(20, 88);

            LblBinaryInput.Name =
                "LblBinaryInput";

            LblBinaryInput.Text =
                "Binär";


            // -----------------------------------------------------
            // Decimal IP 1
            // -----------------------------------------------------

            TxtDecimalOctet1.Location =
                new Point(140, 33);

            TxtDecimalOctet1.MaxLength =
                3;

            TxtDecimalOctet1.Name =
                "TxtDecimalOctet1";

            TxtDecimalOctet1.Size =
                new Size(80, 23);

            TxtDecimalOctet1.TabIndex =
                0;

            TxtDecimalOctet1.TextAlign =
                HorizontalAlignment.Center;

            TxtDecimalOctet1.TextChanged +=
                TxtIpDecimal_TextChanged;

            TxtDecimalOctet1.Enter +=
                Txt_SelectAllOnEnter;


            // -----------------------------------------------------
            // Decimal IP 2
            // -----------------------------------------------------

            TxtDecimalOctet2.Location =
                new Point(245, 33);

            TxtDecimalOctet2.MaxLength =
                3;

            TxtDecimalOctet2.Name =
                "TxtDecimalOctet2";

            TxtDecimalOctet2.Size =
                new Size(80, 23);

            TxtDecimalOctet2.TabIndex =
                1;

            TxtDecimalOctet2.TextAlign =
                HorizontalAlignment.Center;

            TxtDecimalOctet2.TextChanged +=
                TxtIpDecimal_TextChanged;

            TxtDecimalOctet2.Enter +=
                Txt_SelectAllOnEnter;


            // -----------------------------------------------------
            // Decimal IP 3
            // -----------------------------------------------------

            TxtDecimalOctet3.Location =
                new Point(350, 33);

            TxtDecimalOctet3.MaxLength =
                3;

            TxtDecimalOctet3.Name =
                "TxtDecimalOctet3";

            TxtDecimalOctet3.Size =
                new Size(80, 23);

            TxtDecimalOctet3.TabIndex =
                2;

            TxtDecimalOctet3.TextAlign =
                HorizontalAlignment.Center;

            TxtDecimalOctet3.TextChanged +=
                TxtIpDecimal_TextChanged;

            TxtDecimalOctet3.Enter +=
                Txt_SelectAllOnEnter;


            // -----------------------------------------------------
            // Decimal IP 4
            // -----------------------------------------------------

            TxtDecimalOctet4.Location =
                new Point(455, 33);

            TxtDecimalOctet4.MaxLength =
                3;

            TxtDecimalOctet4.Name =
                "TxtDecimalOctet4";

            TxtDecimalOctet4.Size =
                new Size(80, 23);

            TxtDecimalOctet4.TabIndex =
                3;

            TxtDecimalOctet4.TextAlign =
                HorizontalAlignment.Center;

            TxtDecimalOctet4.TextChanged +=
                TxtIpDecimal_TextChanged;

            TxtDecimalOctet4.Enter +=
                Txt_SelectAllOnEnter;


            // -----------------------------------------------------
            // Binary 1
            // -----------------------------------------------------

            TxtOctet1.Location =
                new Point(140, 83);

            TxtOctet1.MaxLength =
                8;

            TxtOctet1.Name =
                "TxtOctet1";

            TxtOctet1.Size =
                new Size(80, 23);

            TxtOctet1.TabIndex =
                4;

            TxtOctet1.TextAlign =
                HorizontalAlignment.Center;

            TxtOctet1.TextChanged +=
                TxtIpBinary_TextChanged;

            TxtOctet1.Enter +=
                Txt_SelectAllOnEnter;


            // -----------------------------------------------------
            // Binary 2
            // -----------------------------------------------------

            TxtOctet2.Location =
                new Point(245, 83);

            TxtOctet2.MaxLength =
                8;

            TxtOctet2.Name =
                "TxtOctet2";

            TxtOctet2.Size =
                new Size(80, 23);

            TxtOctet2.TabIndex =
                5;

            TxtOctet2.TextAlign =
                HorizontalAlignment.Center;

            TxtOctet2.TextChanged +=
                TxtIpBinary_TextChanged;

            TxtOctet2.Enter +=
                Txt_SelectAllOnEnter;


            // -----------------------------------------------------
            // Binary 3
            // -----------------------------------------------------

            TxtOctet3.Location =
                new Point(350, 83);

            TxtOctet3.MaxLength =
                8;

            TxtOctet3.Name =
                "TxtOctet3";

            TxtOctet3.Size =
                new Size(80, 23);

            TxtOctet3.TabIndex =
                6;

            TxtOctet3.TextAlign =
                HorizontalAlignment.Center;

            TxtOctet3.TextChanged +=
                TxtIpBinary_TextChanged;

            TxtOctet3.Enter +=
                Txt_SelectAllOnEnter;


            // -----------------------------------------------------
            // Binary 4
            // -----------------------------------------------------

            TxtOctet4.Location =
                new Point(455, 83);

            TxtOctet4.MaxLength =
                8;

            TxtOctet4.Name =
                "TxtOctet4";

            TxtOctet4.Size =
                new Size(80, 23);

            TxtOctet4.TabIndex =
                7;

            TxtOctet4.TextAlign =
                HorizontalAlignment.Center;

            TxtOctet4.TextChanged +=
                TxtIpBinary_TextChanged;

            TxtOctet4.Enter +=
                Txt_SelectAllOnEnter;


            // -----------------------------------------------------
            // Current IP caption
            // -----------------------------------------------------

            LblCurrentIpCaption.AutoSize =
                true;

            LblCurrentIpCaption.Location =
                new Point(620, 37);

            LblCurrentIpCaption.Name =
                "LblCurrentIpCaption";

            LblCurrentIpCaption.Text =
                "Aktuelle IPv4-Adresse";


            // -----------------------------------------------------
            // Current IP
            // -----------------------------------------------------

            LblCurrentIpValue.AutoSize =
                true;

            LblCurrentIpValue.Font =
                new Font(
                    "Segoe UI",
                    15F,
                    FontStyle.Bold
                );

            LblCurrentIpValue.Location =
                new Point(620, 61);

            LblCurrentIpValue.Name =
                "LblCurrentIpValue";

            LblCurrentIpValue.Text =
                "—";


            // -----------------------------------------------------
            // Hint
            // -----------------------------------------------------

            LblIpHint.AutoSize =
                true;

            LblIpHint.ForeColor =
                SystemColors.GrayText;

            LblIpHint.Location =
                new Point(20, 135);

            LblIpHint.Name =
                "LblIpHint";

            LblIpHint.Text =
                "Beide Zeilen sind editierbar: Dezimal ↔ Binär wird live synchronisiert.";


            /*
             * ToolTips
             */
            TipHelp.SetToolTip(
                TxtDecimalOctet1,
                "IPv4-Oktett: Dezimalwert von 0 bis 255."
            );


            TipHelp.SetToolTip(
                TxtOctet1,
                "IPv4-Oktett: Binärwert mit maximal 8 Bit."
            );


            GrpIp.Controls.Add(
                LblDecimalInput
            );

            GrpIp.Controls.Add(
                LblBinaryInput
            );


            GrpIp.Controls.Add(
                TxtDecimalOctet1
            );

            GrpIp.Controls.Add(
                TxtDecimalOctet2
            );

            GrpIp.Controls.Add(
                TxtDecimalOctet3
            );

            GrpIp.Controls.Add(
                TxtDecimalOctet4
            );


            GrpIp.Controls.Add(
                TxtOctet1
            );

            GrpIp.Controls.Add(
                TxtOctet2
            );

            GrpIp.Controls.Add(
                TxtOctet3
            );

            GrpIp.Controls.Add(
                TxtOctet4
            );


            GrpIp.Controls.Add(
                LblCurrentIpCaption
            );

            GrpIp.Controls.Add(
                LblCurrentIpValue
            );

            GrpIp.Controls.Add(
                LblIpHint
            );


            // =====================================================
            // GROUP: SUBNET
            // =====================================================

            GrpSubnet.Location =
                new Point(20, 200);

            GrpSubnet.Name =
                "GrpSubnet";

            GrpSubnet.Size =
                new Size(1140, 155);

            GrpSubnet.TabIndex =
                1;

            GrpSubnet.TabStop =
                false;

            GrpSubnet.Text =
                "Subnetz / CIDR";


            LblCidr.AutoSize =
                true;

            LblCidr.Location =
                new Point(20, 36);

            LblCidr.Name =
                "LblCidr";

            LblCidr.Text =
                "CIDR";


            NudCidr.Location =
                new Point(70, 31);

            NudCidr.Maximum =
                32;

            NudCidr.Minimum =
                0;

            NudCidr.Name =
                "NudCidr";

            NudCidr.Size =
                new Size(65, 23);

            NudCidr.TabIndex =
                8;

            NudCidr.TextAlign =
                HorizontalAlignment.Center;

            NudCidr.Value =
                24;

            NudCidr.ValueChanged +=
                NudCidr_ValueChanged;


            LblSubnetMask.AutoSize =
                true;

            LblSubnetMask.Location =
                new Point(180, 36);

            LblSubnetMask.Name =
                "LblSubnetMask";

            LblSubnetMask.Text =
                "Subnetzmaske";


            // -----------------------------------------------------
            // Mask 1
            // -----------------------------------------------------

            TxtMaskOctet1.Location =
                new Point(280, 31);

            TxtMaskOctet1.MaxLength =
                3;

            TxtMaskOctet1.Name =
                "TxtMaskOctet1";

            TxtMaskOctet1.Size =
                new Size(70, 23);

            TxtMaskOctet1.TabIndex =
                9;

            TxtMaskOctet1.TextAlign =
                HorizontalAlignment.Center;

            TxtMaskOctet1.TextChanged +=
                TxtMask_TextChanged;

            TxtMaskOctet1.Enter +=
                Txt_SelectAllOnEnter;


            // -----------------------------------------------------
            // Mask 2
            // -----------------------------------------------------

            TxtMaskOctet2.Location =
                new Point(375, 31);

            TxtMaskOctet2.MaxLength =
                3;

            TxtMaskOctet2.Name =
                "TxtMaskOctet2";

            TxtMaskOctet2.Size =
                new Size(70, 23);

            TxtMaskOctet2.TabIndex =
                10;

            TxtMaskOctet2.TextAlign =
                HorizontalAlignment.Center;

            TxtMaskOctet2.TextChanged +=
                TxtMask_TextChanged;

            TxtMaskOctet2.Enter +=
                Txt_SelectAllOnEnter;


            // -----------------------------------------------------
            // Mask 3
            // -----------------------------------------------------

            TxtMaskOctet3.Location =
                new Point(470, 31);

            TxtMaskOctet3.MaxLength =
                3;

            TxtMaskOctet3.Name =
                "TxtMaskOctet3";

            TxtMaskOctet3.Size =
                new Size(70, 23);

            TxtMaskOctet3.TabIndex =
                11;

            TxtMaskOctet3.TextAlign =
                HorizontalAlignment.Center;

            TxtMaskOctet3.TextChanged +=
                TxtMask_TextChanged;

            TxtMaskOctet3.Enter +=
                Txt_SelectAllOnEnter;


            // -----------------------------------------------------
            // Mask 4
            // -----------------------------------------------------

            TxtMaskOctet4.Location =
                new Point(565, 31);

            TxtMaskOctet4.MaxLength =
                3;

            TxtMaskOctet4.Name =
                "TxtMaskOctet4";

            TxtMaskOctet4.Size =
                new Size(70, 23);

            TxtMaskOctet4.TabIndex =
                12;

            TxtMaskOctet4.TextAlign =
                HorizontalAlignment.Center;

            TxtMaskOctet4.TextChanged +=
                TxtMask_TextChanged;

            TxtMaskOctet4.Enter +=
                Txt_SelectAllOnEnter;


            // -----------------------------------------------------
            // Binary mask
            // -----------------------------------------------------

            LblMaskBinaryValue.AutoSize =
                true;

            LblMaskBinaryValue.Font =
                new Font(
                    "Consolas",
                    9F,
                    FontStyle.Regular
                );

            LblMaskBinaryValue.Location =
                new Point(20, 80);

            LblMaskBinaryValue.Name =
                "LblMaskBinaryValue";

            LblMaskBinaryValue.Text =
                "Binär: —";


            // -----------------------------------------------------
            // Prefix info
            // -----------------------------------------------------

            LblPrefixInfoValue.AutoSize =
                true;

            LblPrefixInfoValue.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold
                );

            LblPrefixInfoValue.Location =
                new Point(20, 112);

            LblPrefixInfoValue.Name =
                "LblPrefixInfoValue";

            LblPrefixInfoValue.Text =
                "—";


            TipHelp.SetToolTip(
                NudCidr,
                "CIDR-Präfix: Anzahl der Network Bits von 0 bis 32."
            );


            TipHelp.SetToolTip(
                TxtMaskOctet1,
                "Die Subnetzmaske kann direkt bearbeitet werden."
            );


            GrpSubnet.Controls.Add(
                LblCidr
            );

            GrpSubnet.Controls.Add(
                NudCidr
            );

            GrpSubnet.Controls.Add(
                LblSubnetMask
            );


            GrpSubnet.Controls.Add(
                TxtMaskOctet1
            );

            GrpSubnet.Controls.Add(
                TxtMaskOctet2
            );

            GrpSubnet.Controls.Add(
                TxtMaskOctet3
            );

            GrpSubnet.Controls.Add(
                TxtMaskOctet4
            );


            GrpSubnet.Controls.Add(
                LblMaskBinaryValue
            );

            GrpSubnet.Controls.Add(
                LblPrefixInfoValue
            );


            // =====================================================
            // GROUP: RESULTS
            // =====================================================

            GrpResults.Location =
                new Point(20, 365);

            GrpResults.Name =
                "GrpResults";

            GrpResults.Size =
                new Size(1140, 180);

            GrpResults.TabIndex =
                2;

            GrpResults.TabStop =
                false;

            GrpResults.Text =
                "Subnetz-Auswertung";


            // -----------------------------------------------------
            // Network
            // -----------------------------------------------------

            LblNetworkCaption.AutoSize =
                true;

            LblNetworkCaption.Location =
                new Point(20, 32);

            LblNetworkCaption.Name =
                "LblNetworkCaption";

            LblNetworkCaption.Text =
                "Netzwerkadresse:";


            LblNetworkValue.AutoSize =
                true;

            LblNetworkValue.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold
                );

            LblNetworkValue.Location =
                new Point(145, 32);

            LblNetworkValue.Name =
                "LblNetworkValue";

            LblNetworkValue.Text =
                "—";


            // -----------------------------------------------------
            // Broadcast
            // -----------------------------------------------------

            LblBroadcastCaption.AutoSize =
                true;

            LblBroadcastCaption.Location =
                new Point(20, 67);

            LblBroadcastCaption.Name =
                "LblBroadcastCaption";

            LblBroadcastCaption.Text =
                "Broadcast:";


            LblBroadcastValue.AutoSize =
                true;

            LblBroadcastValue.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold
                );

            LblBroadcastValue.Location =
                new Point(145, 67);

            LblBroadcastValue.Name =
                "LblBroadcastValue";

            LblBroadcastValue.Text =
                "—";


            // -----------------------------------------------------
            // Wildcard
            // -----------------------------------------------------

            LblWildcardCaption.AutoSize =
                true;

            LblWildcardCaption.Location =
                new Point(20, 102);

            LblWildcardCaption.Name =
                "LblWildcardCaption";

            LblWildcardCaption.Text =
                "Wildcard Mask:";


            LblWildcardValue.AutoSize =
                true;

            LblWildcardValue.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold
                );

            LblWildcardValue.Location =
                new Point(145, 102);

            LblWildcardValue.Name =
                "LblWildcardValue";

            LblWildcardValue.Text =
                "—";


            // -----------------------------------------------------
            // First host
            // -----------------------------------------------------

            LblFirstHostCaption.AutoSize =
                true;

            LblFirstHostCaption.Location =
                new Point(330, 32);

            LblFirstHostCaption.Name =
                "LblFirstHostCaption";

            LblFirstHostCaption.Text =
                "Erster Host:";


            LblFirstHostValue.AutoSize =
                true;

            LblFirstHostValue.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold
                );

            LblFirstHostValue.Location =
                new Point(435, 32);

            LblFirstHostValue.Name =
                "LblFirstHostValue";

            LblFirstHostValue.Text =
                "—";


            // -----------------------------------------------------
            // Last host
            // -----------------------------------------------------

            LblLastHostCaption.AutoSize =
                true;

            LblLastHostCaption.Location =
                new Point(330, 67);

            LblLastHostCaption.Name =
                "LblLastHostCaption";

            LblLastHostCaption.Text =
                "Letzter Host:";


            LblLastHostValue.AutoSize =
                true;

            LblLastHostValue.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold
                );

            LblLastHostValue.Location =
                new Point(435, 67);

            LblLastHostValue.Name =
                "LblLastHostValue";

            LblLastHostValue.Text =
                "—";


            // -----------------------------------------------------
            // Address type
            // -----------------------------------------------------

            LblAddressTypeCaption.AutoSize =
                true;

            LblAddressTypeCaption.Location =
                new Point(330, 102);

            LblAddressTypeCaption.Name =
                "LblAddressTypeCaption";

            LblAddressTypeCaption.Text =
                "Adresstyp:";


            LblAddressTypeValue.AutoSize =
                true;

            LblAddressTypeValue.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold
                );

            LblAddressTypeValue.Location =
                new Point(435, 102);

            LblAddressTypeValue.Name =
                "LblAddressTypeValue";

            LblAddressTypeValue.Text =
                "—";


            // -----------------------------------------------------
            // Total addresses
            // -----------------------------------------------------

            LblTotalAddressesCaption.AutoSize =
                true;

            LblTotalAddressesCaption.Location =
                new Point(680, 32);

            LblTotalAddressesCaption.Name =
                "LblTotalAddressesCaption";

            LblTotalAddressesCaption.Text =
                "Adressen gesamt:";


            LblTotalAddressesValue.AutoSize =
                true;

            LblTotalAddressesValue.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold
                );

            LblTotalAddressesValue.Location =
                new Point(810, 32);

            LblTotalAddressesValue.Name =
                "LblTotalAddressesValue";

            LblTotalAddressesValue.Text =
                "—";


            // -----------------------------------------------------
            // Usable hosts
            // -----------------------------------------------------

            LblUsableHostsCaption.AutoSize =
                true;

            LblUsableHostsCaption.Location =
                new Point(680, 67);

            LblUsableHostsCaption.Name =
                "LblUsableHostsCaption";

            LblUsableHostsCaption.Text =
                "Nutzbare Hosts:";


            LblUsableHostsValue.AutoSize =
                true;

            LblUsableHostsValue.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold
                );

            LblUsableHostsValue.Location =
                new Point(810, 67);

            LblUsableHostsValue.Name =
                "LblUsableHostsValue";

            LblUsableHostsValue.Text =
                "—";


            // -----------------------------------------------------
            // Bit split
            // -----------------------------------------------------

            LblNetworkBitsCaption.AutoSize =
                true;

            LblNetworkBitsCaption.Location =
                new Point(680, 102);

            LblNetworkBitsCaption.Name =
                "LblNetworkBitsCaption";

            LblNetworkBitsCaption.Text =
                "Bit-Aufteilung:";


            LblNetworkBitsValue.AutoSize =
                true;

            LblNetworkBitsValue.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold
                );

            LblNetworkBitsValue.Location =
                new Point(810, 102);

            LblNetworkBitsValue.Name =
                "LblNetworkBitsValue";

            LblNetworkBitsValue.Text =
                "—";


            // -----------------------------------------------------
            // Example
            // -----------------------------------------------------

            CmdExample.Location =
                new Point(680, 135);

            CmdExample.Name =
                "CmdExample";

            CmdExample.Size =
                new Size(200, 28);

            CmdExample.TabIndex =
                13;

            CmdExample.Text =
                "Beispiel 192.168.1.10/24";

            CmdExample.UseVisualStyleBackColor =
                true;

            CmdExample.Click +=
                CmdExample_Click;


            // -----------------------------------------------------
            // Reset
            // -----------------------------------------------------

            CmdReset.Location =
                new Point(900, 135);

            CmdReset.Name =
                "CmdReset";

            CmdReset.Size =
                new Size(200, 28);

            CmdReset.TabIndex =
                14;

            CmdReset.Text =
                "Zurücksetzen";

            CmdReset.UseVisualStyleBackColor =
                true;

            CmdReset.Click +=
                CmdReset_Click;


            GrpResults.Controls.Add(
                LblNetworkCaption
            );

            GrpResults.Controls.Add(
                LblNetworkValue
            );


            GrpResults.Controls.Add(
                LblBroadcastCaption
            );

            GrpResults.Controls.Add(
                LblBroadcastValue
            );


            GrpResults.Controls.Add(
                LblWildcardCaption
            );

            GrpResults.Controls.Add(
                LblWildcardValue
            );


            GrpResults.Controls.Add(
                LblFirstHostCaption
            );

            GrpResults.Controls.Add(
                LblFirstHostValue
            );


            GrpResults.Controls.Add(
                LblLastHostCaption
            );

            GrpResults.Controls.Add(
                LblLastHostValue
            );


            GrpResults.Controls.Add(
                LblAddressTypeCaption
            );

            GrpResults.Controls.Add(
                LblAddressTypeValue
            );


            GrpResults.Controls.Add(
                LblTotalAddressesCaption
            );

            GrpResults.Controls.Add(
                LblTotalAddressesValue
            );


            GrpResults.Controls.Add(
                LblUsableHostsCaption
            );

            GrpResults.Controls.Add(
                LblUsableHostsValue
            );


            GrpResults.Controls.Add(
                LblNetworkBitsCaption
            );

            GrpResults.Controls.Add(
                LblNetworkBitsValue
            );


            GrpResults.Controls.Add(
                CmdExample
            );

            GrpResults.Controls.Add(
                CmdReset
            );


            // =====================================================
            // GROUP: 32 BIT
            // =====================================================

            GrpBits.Location =
                new Point(20, 555);

            GrpBits.Name =
                "GrpBits";

            GrpBits.Size =
                new Size(1140, 205);

            GrpBits.TabIndex =
                3;

            GrpBits.TabStop =
                false;

            GrpBits.Text =
                "32-Bit-Visualisierung";


            /*
             * Eigene DoubleBufferedTableLayoutPanel-Class.
             */
            TblBinaryMap.CellBorderStyle =
                TableLayoutPanelCellBorderStyle.Single;


            TblBinaryMap.ColumnCount =
                34;


            /*
             * Name der Zeile.
             */
            TblBinaryMap.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Absolute,
                    105F
                )
            );


            /*
             * 32 Bit-Spalten.
             */
            for (int i = 0;
                 i < 32;
                 i++)
            {
                TblBinaryMap.ColumnStyles.Add(
                    new ColumnStyle(
                        SizeType.Absolute,
                        24F
                    )
                );
            }


            /*
             * Dotted-decimal Ausgabe.
             */
            TblBinaryMap.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Absolute,
                    180F
                )
            );


            TblBinaryMap.Font =
                new Font(
                    "Consolas",
                    8F,
                    FontStyle.Regular
                );


            TblBinaryMap.GrowStyle =
                TableLayoutPanelGrowStyle.FixedSize;


            TblBinaryMap.Location =
                new Point(15, 25);


            TblBinaryMap.Name =
                "TblBinaryMap";


            TblBinaryMap.RowCount =
                6;


            for (int i = 0;
                 i < 6;
                 i++)
            {
                TblBinaryMap.RowStyles.Add(
                    new RowStyle(
                        SizeType.Absolute,
                        22F
                    )
                );
            }


            TblBinaryMap.Size =
                new Size(1105, 140);


            TblBinaryMap.TabIndex =
                15;


            // -----------------------------------------------------
            // Network legend
            // -----------------------------------------------------

            LblNetworkLegend.AutoSize =
                false;

            LblNetworkLegend.BackColor =
                NetworkBitColor;

            LblNetworkLegend.Location =
                new Point(15, 170);

            LblNetworkLegend.Name =
                "LblNetworkLegend";

            LblNetworkLegend.Size =
                new Size(135, 22);

            LblNetworkLegend.Text =
                "Network Bits";

            LblNetworkLegend.TextAlign =
                ContentAlignment.MiddleCenter;


            // -----------------------------------------------------
            // Host legend
            // -----------------------------------------------------

            LblHostLegend.AutoSize =
                false;

            LblHostLegend.BackColor =
                HostBitColor;

            LblHostLegend.Location =
                new Point(165, 170);

            LblHostLegend.Name =
                "LblHostLegend";

            LblHostLegend.Size =
                new Size(135, 22);

            LblHostLegend.Text =
                "Host Bits";

            LblHostLegend.TextAlign =
                ContentAlignment.MiddleCenter;


            GrpBits.Controls.Add(
                TblBinaryMap
            );


            GrpBits.Controls.Add(
                LblNetworkLegend
            );


            GrpBits.Controls.Add(
                LblHostLegend
            );


            // =====================================================
            // ERROR PROVIDER
            // =====================================================

            ErrInput.ContainerControl =
                this;


            // =====================================================
            // STATUS
            // =====================================================

            StatusMain.Dock =
                DockStyle.Bottom;


            StatusMain.Items.AddRange(
                new ToolStripItem[]
                {
                    StsState
                }
            );


            StatusMain.Name =
                "StatusMain";


            StatusMain.SizingGrip =
                false;


            StsState.Name =
                "StsState";


            StsState.Text =
                "Bereit";


            // =====================================================
            // FORM
            // =====================================================

            AutoScaleDimensions =
                new SizeF(7F, 15F);


            AutoScaleMode =
                AutoScaleMode.Font;


            AutoScroll =
                true;


            ClientSize =
                new Size(1180, 805);


            Controls.Add(
                GrpIp
            );


            Controls.Add(
                GrpSubnet
            );


            Controls.Add(
                GrpResults
            );


            Controls.Add(
                GrpBits
            );


            Controls.Add(
                StatusMain
            );


            MinimumSize =
                new Size(1200, 850);


            Name =
                "BinaryCalculator";


            StartPosition =
                FormStartPosition.CenterScreen;


            Text =
                "IPv4 Subnet Calculator & Binary Visualizer";


            ((System.ComponentModel.ISupportInitialize)
                NudCidr).EndInit();


            ((System.ComponentModel.ISupportInitialize)
                ErrInput).EndInit();


            GrpIp.ResumeLayout(false);
            GrpIp.PerformLayout();


            GrpSubnet.ResumeLayout(false);
            GrpSubnet.PerformLayout();


            GrpResults.ResumeLayout(false);
            GrpResults.PerformLayout();


            GrpBits.ResumeLayout(false);


            StatusMain.ResumeLayout(false);
            StatusMain.PerformLayout();


            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        // =========================================================
        // GROUPS
        // =========================================================

        private GroupBox GrpIp;
        private GroupBox GrpSubnet;
        private GroupBox GrpResults;
        private GroupBox GrpBits;


        // =========================================================
        // IP
        // =========================================================

        private Label LblDecimalInput;
        private Label LblBinaryInput;


        private TextBox TxtDecimalOctet1;
        private TextBox TxtDecimalOctet2;
        private TextBox TxtDecimalOctet3;
        private TextBox TxtDecimalOctet4;


        private TextBox TxtOctet1;
        private TextBox TxtOctet2;
        private TextBox TxtOctet3;
        private TextBox TxtOctet4;


        private Label LblCurrentIpCaption;
        private Label LblCurrentIpValue;

        private Label LblIpHint;


        // =========================================================
        // SUBNET
        // =========================================================

        private Label LblCidr;

        private NumericUpDown NudCidr;


        private Label LblSubnetMask;


        private TextBox TxtMaskOctet1;
        private TextBox TxtMaskOctet2;
        private TextBox TxtMaskOctet3;
        private TextBox TxtMaskOctet4;


        private Label LblMaskBinaryValue;
        private Label LblPrefixInfoValue;


        // =========================================================
        // RESULTS
        // =========================================================

        private Label LblNetworkCaption;
        private Label LblNetworkValue;


        private Label LblBroadcastCaption;
        private Label LblBroadcastValue;


        private Label LblFirstHostCaption;
        private Label LblFirstHostValue;


        private Label LblLastHostCaption;
        private Label LblLastHostValue;


        private Label LblWildcardCaption;
        private Label LblWildcardValue;


        private Label LblTotalAddressesCaption;
        private Label LblTotalAddressesValue;


        private Label LblUsableHostsCaption;
        private Label LblUsableHostsValue;


        private Label LblNetworkBitsCaption;
        private Label LblNetworkBitsValue;


        private Label LblAddressTypeCaption;
        private Label LblAddressTypeValue;


        private Button CmdExample;
        private Button CmdReset;


        // =========================================================
        // BIT VISUALIZATION
        // =========================================================

        private DoubleBufferedTableLayoutPanel TblBinaryMap;

        private Label LblNetworkLegend;
        private Label LblHostLegend;


        // =========================================================
        // COMPONENTS
        // =========================================================

        private ErrorProvider ErrInput;

        private ToolTip TipHelp;


        private StatusStrip StatusMain;

        private ToolStripStatusLabel StsState;
    }
}