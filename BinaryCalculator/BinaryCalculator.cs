using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MB01.A1_2_5
{
    public partial class BinaryCalculator : Form
    {
        public BinaryCalculator()
        {
            InitializeComponent();
        }

        private void CmdBit128_Click(object sender, EventArgs e)
        {
            /*
                CmdBit128  → konkreter Button
                .Text      → Property für den sichtbaren Text
                 =         → Zuweisungsoperator
                "1"        → neuer String-Wert
            */
            CmdBit128.Text = "1";
        }

        private void CmdBit64_Click(object sender, EventArgs e)
        {
            /*
                CmdBit64   → konkreter Button
                .Text      → Property für den sichtbaren Text
                 =         → Zuweisungsoperator
                "1"        → neuer String-Wert
            */
            CmdBit64.Text = "1";
        }

        private void CmdBit32_Click(object sender, EventArgs e)
        {
            CmdBit32.Text = "1";
        }

        private void CmdBit16_Click(object sender, EventArgs e)
        {
            CmdBit16.Text = "1";
        }

        private void CmdBit8_Click(object sender, EventArgs e)
        {
            CmdBit8.Text = "1";
        }

        private void CmdBit4_Click(object sender, EventArgs e)
        {
            CmdBit4.Text = "1";
        }

        private void CmdBit2_Click(object sender, EventArgs e)
        {
            CmdBit2.Text = "1";
        }

        private void CmdBit1_Click(object sender, EventArgs e)
        {
            CmdBit1.Text = "1";
        }

        private void CmdCalculateDecimal_Click(object sender, EventArgs e)
        {
            /*
             * Die Text-Properties der acht Bit-Buttons werden von links nach rechts
             * zu einem zusammenhängenden Binär-String verkettet.
             *
             * Beispiel:
             * 1 0 0 0 1 1 0 1
             *
             * ergibt:
             * "10001101"
             */
            string binaryValue =
                CmdBit128.Text +
                CmdBit64.Text +
                CmdBit32.Text +
                CmdBit16.Text +
                CmdBit8.Text +
                CmdBit4.Text +
                CmdBit2.Text +
                CmdBit1.Text;

            /*
             * Convert.ToInt16(binaryValue, 2) konvertiert den Binär-String
             * in einen ganzzahligen Wert vom Typ Int16.
             *
             * Der zweite Parameter 2 gibt die Zahlenbasis an:
             * Basis 2 = Binärsystem.
             *
             * Beispiel:
             * "00000011" → 3
             *
             * Der Rückgabewert von Convert.ToInt16(...) besitzt den Datentyp Int16.
             * In C# ist "short" lediglich der sprachinterne Alias für System.Int16.
             *
             * Somit sind folgende Schreibweisen vom Datentyp her gleichbedeutend:
             *
             * short decimalValue
             * System.Int16 decimalValue
             *
             * Für die hier verwendeten 8 Bits reicht Int16 problemlos aus,
             * da der grösstmögliche Binärwert 11111111 dem Dezimalwert 255 entspricht.
             */
            short decimalValue = Convert.ToInt16(binaryValue, 2);

            /*
             * Der berechnete Dezimalwert wird über String-Interpolation
             * in die Text-Property des Labels geschrieben.
             */
            LblDecimalValue.Text = $"Wert in Dezimal: {decimalValue}";
        }

        private void CmdReset_Click(object sender, EventArgs e)
        {
            /*
             * Setzt alle Bit-Buttons wieder auf den Ausgangszustand "0"
             * und setzt auch die Dezimalausgabe zurück.
             */
            CmdBit128.Text = "0";
            CmdBit64.Text = "0";
            CmdBit32.Text = "0";
            CmdBit16.Text = "0";
            CmdBit8.Text = "0";
            CmdBit4.Text = "0";
            CmdBit2.Text = "0";
            CmdBit1.Text = "0";

            LblDecimalValue.Text = "Wert in Dezimal: 0";
        }
    }
}
