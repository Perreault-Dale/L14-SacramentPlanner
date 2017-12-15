using SacramentPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Data
{
    public class DbInitializer
    {
        public static void Initialize(SacramentContext context)
        {
            //check for programs
            if (context.Programs.Any())
            {
                return;
            }

            var programs = new MeetingProgram[]
            {
                new MeetingProgram{programDate = DateTime.Parse("2016-09-01"),Conduct="Br. Worthington",Preside="Bishop Christensen",Sacrament=true}
            };
            foreach (MeetingProgram m in programs)
            {
                context.Programs.Add(m);
            }
            context.SaveChanges();

            var hymns = new Hymn[]
            {
                new Hymn{MeetingProgramID=1,hymnNumber=20,name="Come, Come Ye Saints",location=HymnLocation.Opening},
                new Hymn{MeetingProgramID=1,hymnNumber=175,name="O God, The Eternal Father",location=HymnLocation.Sacrament},
                new Hymn{MeetingProgramID=1,hymnNumber=81,name="Press Forward, Saints",location=HymnLocation.Intermediate},
                new Hymn{MeetingProgramID=1,hymnNumber=2,name="The Spirit of God",location=HymnLocation.Closing}
            };
            foreach (Hymn h in hymns)
            {
                context.Hymns.Add(h);
            }
            context.SaveChanges();

            var talks = new Talk[]
            {
                new Talk{MeetingProgramID=1,speaker="Gordon Smith",topic="Baptism",Reading="Mosiah 18:8-10",order=1},
                new Talk{MeetingProgramID=1,speaker="Jennifer Smith",topic="The Gift of the Holy Ghost",Reading="Moroni 10:3-5",order=2},
                new Talk{MeetingProgramID=1,speaker="Doug Smith",topic="Endure to the End",Reading="2 Nephi 31:19-21",order=3}
            };
            foreach (Talk t in talks)
            {
                context.Talks.Add(t);
            }
            context.SaveChanges();

            var prayers = new Prayer[]
            {
                new Prayer{MeetingProgramID=1,speaker="Celeste Smith",location=PrayerLocation.Invocation},
                new Prayer{MeetingProgramID=1,speaker="Vernon Smith",location=PrayerLocation.Benediction}
            };
            foreach (Prayer p in prayers)
            {
                context.Prayers.Add(p);
            }
            context.SaveChanges();
        }
    }
}
