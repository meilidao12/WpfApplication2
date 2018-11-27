using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication2.Models
{
    public class MySqlModel
    {


        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public void SendData()
        {
           
        }

        //public string HDD_SIM
        //{
        //    get
        //    {
        //        return hDD_SIM;
        //    }

        //    set
        //    {
        //        hDD_SIM = value;
        //    }
        //}

        //public decimal HDD_InstantFlux
        //{
        //    get
        //    {
        //        return hDD_InstantFlux;
        //    }

        //    set
        //    {
        //        hDD_InstantFlux = value;
        //    }
        //}

        //public decimal HDD_CumFlux
        //{
        //    get
        //    {
        //        return hDD_CumFlux;
        //    }

        //    set
        //    {
        //        hDD_CumFlux = value;
        //    }
        //}

        //public DateTime HDD_CollectTime
        //{
        //    get
        //    {
        //        return hDD_CollectTime;
        //    }

        //    set
        //    {
        //        hDD_CollectTime = value;
        //    }
        //}

        //private DateTime hDD_CollectTime;

        //private decimal hDD_CumFlux;

        //private decimal  hDD_InstantFlux;

        //private string hDD_SIM;

        string phone;

        string id;

        string name;

        string age;
    }
}
