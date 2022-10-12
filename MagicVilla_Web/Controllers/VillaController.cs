using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dtos;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MagicVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;

        public VillaController(IVillaService villaService, IMapper mapper)
        {
            _villaService = villaService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDTO> list = new();

            var response = await _villaService.GetAllAsync<ApiResponse>(HttpContext.Session.GetString(MagicVilla_Utility.SD.SessionToken));
            if (response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));    
            }

            return View(list);
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateVilla()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla(VillaCreateDTO dto)
        {
            if(ModelState.IsValid)
            {
                var response = await _villaService.CreateAsync<ApiResponse>(dto, HttpContext.Session.GetString(MagicVilla_Utility.SD.SessionToken));
                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }
            }

            return View(dto);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateVilla(int villaId)
        {
            var response = await _villaService.GetAsync<ApiResponse>(villaId, HttpContext.Session.GetString(MagicVilla_Utility.SD.SessionToken));
            if (response.IsSuccess)
            {
                VillaDTO dto = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<VillaUpdateDTO>(dto));    
            }

            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVilla(VillaUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.UpdateAsync<ApiResponse>(dto, HttpContext.Session.GetString(MagicVilla_Utility.SD.SessionToken));
                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }
            }

            return View(dto);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteVilla(int villaId)
        {
            var response = await _villaService.GetAsync<ApiResponse>(villaId, HttpContext.Session.GetString(MagicVilla_Utility.SD.SessionToken));
            if (response.IsSuccess)
            {
                VillaDTO dto = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                return View(dto);
            }

            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVilla(VillaDTO dto)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.DeleteAsync<ApiResponse>(dto.Id, HttpContext.Session.GetString(MagicVilla_Utility.SD.SessionToken));
                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }
            }

            return View(dto);
        }
    }
}
