﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP.Library.Models;

namespace PP.Library.Services
{
    public class TimeService
    {
        private static TimeService? instance;
        public static TimeService Current
        {
            get 
            {
                if (instance == null)
                {
                    instance = new TimeService();
                }
                return instance;
            }
        }

        private List<Time> times;
        private TimeService()
        {
            times = new List<Time>();
        }
        public List<Time> Times
        {
            get { return times; }
        }
        public Time? GetTime(int id)
        {
            return times.FirstOrDefault(p => p.Id == id);
        }

        public void AddOrUpdateTime(Time time)
        {
            if (time != null)
            {
                var timeToUpdate = times.FirstOrDefault(e => e.Id == time.Id);
                if (timeToUpdate != null)
                {
                    timeToUpdate.Date = time.Date;
                    timeToUpdate.Narrative = time.Narrative;
                    timeToUpdate.Hours = time.Hours;
                    timeToUpdate.ProjectId = time.ProjectId;
                    timeToUpdate.EmployeeId = time.EmployeeId;
                }
                else
                {
                    time.Id = LastId + 1;
                    times.Add(time);
                }
            }

        }

        public void DeleteTime(int id)
        {
            var timeToRemove = times.FirstOrDefault(p => p.ProjectId == id);
            if (timeToRemove != null)
            {
                times.Remove(timeToRemove);
            }

        }

        public void UpdateTime(Time time)
        {
            var timeToUpdate = times.FirstOrDefault(p => p.Id == time.Id);
            if (timeToUpdate != null)
            {
                timeToUpdate.Date = time.Date;
                timeToUpdate.Narrative = time.Narrative;
                timeToUpdate.Hours = time.Hours;
                timeToUpdate.ProjectId = time.ProjectId;
                timeToUpdate.EmployeeId = time.EmployeeId;
            }
        }

        private int LastId
        {
            get
            {
                return Times.Any() ? Times.Select(t => t.Id).Max() : 0;
            }
        }
    }
}

