/* UserInterface.cs
 * Author: Rod Howell
 * Modified By: Ebraheem Mustafa
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.CapitalGainCalculator
{
    /// <summary>
    /// A user interface for a simple captial gain calculator for a single stock commodity.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }


        private Queue<decimal> _ownedShares = new Queue<decimal>();

        /// <summary>
        /// An event handler for "Buy" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxBuy_Click(object sender, EventArgs e)
        {
            int shares = Convert.ToInt32(uxNumber.Value);
            decimal cost = uxCost.Value;
            
            for (int a = 0; a < shares; a++)
            {
                _ownedShares.Enqueue(cost);
            }

            //totalShares += (int) shares;
            uxOwned.Text = _ownedShares.Count.ToString();


        }

        /// <summary>
        /// An event handler for "Sell" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSell_Click(object sender, EventArgs e)
        {
            if (_ownedShares.Count < uxNumber.Value)
            {
                MessageBox.Show("User doesn't own that number of shares.");
            }
            else
            {
                decimal currentGain = Convert.ToDecimal(uxGain.Text);
                for (int a = Convert.ToInt32(uxNumber.Value); a > 0; a--)
                {
                  currentGain += ((uxCost.Value - _ownedShares.Dequeue()) ) ;
                    
                }
                

                uxGain.Text = currentGain.ToString();
                uxOwned.Text = _ownedShares.Count.ToString();
            }
        }
    }
}
