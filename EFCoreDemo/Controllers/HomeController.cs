using System;
using System.Diagnostics;
using System.Linq;
using EFCoreDemo.domain;
using Microsoft.AspNetCore.Mvc;
using EFCoreDemo.Models;
using EFCoreDemoo.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Controllers
{
  public class HomeController : Controller
  {
    private readonly MyContext _context;

    public HomeController(MyContext context)
    {
      _context = context;
    }

    public IActionResult Index()
    {
      var province = new Province
      {
        Name = "北京",
        Population = 2_000_000
      };
      var province1 = new Province
      {
        Name = "上海",
        Population = 1_000_000
      };
      var province2 = new Province
      {
        Name = "广东",
        Population = 8_000_000
      };

      var company = new Company
      {
        Name = "Taida",
        EstablishDate = new DateTime(1900, 1, 1),
        LegalPerson = "Secret Man"
      };


      //_context.Add(province);
      // 添加数据
      /*_context.Provinces.AddRange(new List<Province>()
      {
        province, province1, province2
      });*/
      // 提交数据
      _context.SaveChanges();
      return View();
    }

    public IActionResult About()
    {
      ViewData["Message"] = "Your application description page.";

      // 查询所有数据
      var provinces = _context.Provinces.ToList();

      // 将查询条件提取到一个变量中，在查询是会使用参数化查询 如果在方法中硬编码则不会使用参数化查询
      const string whereStr = "北京";

      //根据条件查询所有
      var list = _context.Provinces.Where(s=>s.Name== whereStr).ToList();

      var ss = (from p in _context.Provinces
        where p.Name.Equals("北京")
        select p).ToList();

      var bb = _context.Provinces.Where(x => EF.Functions.Like(x.Name, "%北%")).ToList();
      var lastOrDefault = _context.Provinces.OrderBy(x=>x.Id).LastOrDefault(x=>EF.Functions.Like(x.Name, "%北%"));

      return View();
    }

    public IActionResult Contact()
    {
      ViewData["Message"] = "Your contact page.";

      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
  }
}