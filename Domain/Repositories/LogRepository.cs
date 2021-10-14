﻿using Domain.Interfaces;
using Infra.Data;
using Infra.Helpers;
using Infra.Models.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class LogRepository : ILogRepository
    {
        private ApplicationDbContext _context;
        public LogRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(string description)
        {
            try
            {
                Log log = new Log { Description = description, Date = DateTime.Now };

                await _context.Log.AddAsync(log);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return false;
        }

        public async Task<List<Log>> Get()
        {
            try
            {
                return await _context.Log.ToListAsync();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }

            return default;
        }

        public async Task Remove(List<Log> logs)
        {
            try
            {
                var logsToRemove = await _context.Log.Where(x => logs.Select(x => x.Id).Contains(x.Id)).ToListAsync();

                _context.Log.RemoveRange(logsToRemove);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { LogWriter.Write(ex.ToString()); }
        }
    }
}