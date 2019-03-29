using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using S2.AspNet.Repetition.DAL;
using S2.AspNet.Repetition.Entities;

namespace S2.AspNet.Repetition.Pages
{
    public class CreateMemeModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public MemeCreation MemeCreation { get; set; }
        public void OnGet()
        {
            MemeCreationRepository repo = new MemeCreationRepository();
            repo.Insert(MemeCreation);
            if (string.IsNullOrWhiteSpace(MemeCreation.MemeImage.Url))
            {
                MemeImageRepository imgRepo = new MemeImageRepository();
                MemeCreation.MemeImage.Url = imgRepo.GetMemeImageUrl(MemeCreation.MemeImageId);
            }
        }
    }
}