using MAUIpractice.Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIpractice.Resources.ViewModels
{
    public class ViewPayloadModel
    {
        public PayloadModel PayloadData { get; set; }

        public ViewPayloadModel()
        {
            PayloadData = new();
            PopulatePayloadFields();
            PopulatePayloadArms();
        }

        private void PopulatePayloadFields()
        {

            PayloadData.PayloadFields = new string[16];

            PayloadData.PayloadFields[0] = "Pilot (PIC)";
            PayloadData.PayloadFields[1] = "Pilot (SIC)";
            PayloadData.PayloadFields[2] = "Seat 10 (SFS)";
            PayloadData.PayloadFields[3] = "Seat 3";
            PayloadData.PayloadFields[4] = "Seat 4";
            PayloadData.PayloadFields[5] = "Seat 5";
            PayloadData.PayloadFields[6] = "Seat 6";
            PayloadData.PayloadFields[7] = "Seat 7";
            PayloadData.PayloadFields[8] = "Seat 8";
            PayloadData.PayloadFields[9] = "Seat 9 LH Belted Toilet";
            PayloadData.PayloadFields[10] = "Nose Baggage";
            PayloadData.PayloadFields[11] = "Charts";
            PayloadData.PayloadFields[12] = "LHF Evaporator Cabinet";
            PayloadData.PayloadFields[13] = "RH Slimline Refreshment Center";
            PayloadData.PayloadFields[14] = "LH Aft Vanity";
            PayloadData.PayloadFields[15] = "Tailcone Baggage";

        }

        private void PopulatePayloadArms()
        {

            PayloadData.PayloadArms = new double[16];

            PayloadData.PayloadArms[0] = 131.0;
            PayloadData.PayloadArms[1] = 131.0;
            PayloadData.PayloadArms[2] = 174.2;
            PayloadData.PayloadArms[3] = 202.5;
            PayloadData.PayloadArms[4] = 202.5;
            PayloadData.PayloadArms[5] = 260.5;
            PayloadData.PayloadArms[6] = 260.5;
            PayloadData.PayloadArms[7] = 295.5;
            PayloadData.PayloadArms[8] = 295.5;
            PayloadData.PayloadArms[9] = 322.5;
            PayloadData.PayloadArms[10] = 74.0;
            PayloadData.PayloadArms[11] = 150.9;
            PayloadData.PayloadArms[12] = 156.3;
            PayloadData.PayloadArms[13] = 157.2;
            PayloadData.PayloadArms[14] = 334.9;
            PayloadData.PayloadArms[15] = 414.6;
        }

        public string[] GetFields()
        {
            return PayloadData.PayloadFields;
        }

        public double[] GetArms()
        {
            return PayloadData.PayloadArms;
        }
        
    }
}
