using System;
using System.ComponentModel.DataAnnotations;

namespace PlanoDeAcao.Models
{
    public class ActionPlan
    {
        public int Id { get; set; }
        public string What { get; set; }
        public string Why { get; set; }
        public string Who { get; set; }
        public string Where { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime When { get; set; }
        public string How { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double HowMuch { get; set; }
        public Parecer Parecer { get; set; }        

        public ActionPlan() 
        {
        }

        public ActionPlan(int id, string what, string why, string who, string where, DateTime when, string how, double howMuch, Parecer parecer)
        {
            Id = id;
            What = what;
            Why = why;
            Who = who;
            Where = where;
            When = when;
            How = how;
            HowMuch = howMuch;
            Parecer = parecer;
        }
    }


}
