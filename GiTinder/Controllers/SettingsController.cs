﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GiTinder.Data;
using GiTinder.Models;
using System.Collections;

namespace GiTinder.Controllers
{
    public class SettingsController : Controller
    {
        private readonly GiTinderContext _context;

        public SettingsController(GiTinderContext context)
        {
            _context = context;
        }

        //          Mock GET /settings
        //          Mock PUT /settings
        //          Tests for all

        // GET: Settings
        //[HttpGet]
        //[Route("/settings]")]


        [HttpGet("/settings")]
        public object settings()
        {
            var settings = new Settings("Mock Filip", true, true, 160, new List<Language> { new Language("Java"), new Language( "C#") });

            // Add a range of items  
            //string[] authors = { "Mike Gold", "Don Box",
            //            "Sundar Lal", "Neel Beniwal" };
            //AuthorList.AddRange(authors);
            //settings.PreferredLanguages.Add("Java");
            //settings.PreferredLanguages.Add("C#");
            return settings;
        }



        // GET: Settings

        //[HttpGet("/settings")]
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Settings.ToListAsync());
        //}

        //// GET: Settings/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var settings = await _context.Settings
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (settings == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(settings);
        //}

        //// GET: Settings/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Settings/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,UserName,EnableNotification,MaxDistanceInKm,PreferredLanguages")] Settings settings)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(settings);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(settings);
        //}

        //// GET: Settings/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var settings = await _context.Settings.FindAsync(id);
        //    if (settings == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(settings);
        //}

        //// POST: Settings/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,EnableNotification,MaxDistanceInKm,PreferredLanguages")] Settings settings)
        //{
        //    if (id != settings.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(settings);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SettingsExists(settings.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(settings);
        //}

        //// GET: Settings/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var settings = await _context.Settings
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (settings == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(settings);
        //}

        //// POST: Settings/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var settings = await _context.Settings.FindAsync(id);
        //    _context.Settings.Remove(settings);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SettingsExists(int id)
        //{
        //    return _context.Settings.Any(e => e.Id == id);
        //}
    }
}