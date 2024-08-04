using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarDR.MailSender
{
    public class DRSorter
    {

        public ICollection<PersonForEmail> SearchTodayBirthday(ICollection<PersonForEmail> persons)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var inThisMoth = persons.Where(t => t.Date.Month == today.Month).ToList();
            var todayBirthday = inThisMoth.Where(t => t.Date.Day == today.Day).ToList();

            return todayBirthday;
        }
    }
}
