using Administrador_SAR.DBContext;
using Administrador_SAR.Models.Reports;
using AutoMapper;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Text.Json.Serialization;

namespace Administrador_SAR.Controllers
{
    public class HomeController : Controller
    {
        private RSDBEntities db = new RSDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult dashboard(DateTime? startDate, DateTime? endDate, int countryId = 0, int workPlace = 0)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "Login");
            }

            if (endDate != null) endDate.Value.AddDays(1);

            if (startDate == null) startDate = DateTime.Today.AddDays(-30);
            if (endDate == null) endDate = DateTime.Today.AddDays(1);



            var reports = db.Reports
                            .Include(r => r.StatusReports)
                            .Include(r => r.WorkPlaces).OrderByDescending(x => x.CreatedDate)
                            .Where(x => x.CreatedDate >= startDate && x.CreatedDate <= endDate)
                            .ToList();

            var viewModel = Mapper.Map<IList<ReportResponseViewModel>>(reports).ToList();


            if (countryId != 0)
                viewModel = viewModel.Where(c => c.CountryId == countryId).ToList();

            Highcharts columnChart;
            //Si se filtra por centro de trabajo se debe obtener lso reportes del centro y agruparlos por estado
            if (workPlace != 0)
            {
                var WorkPlaceName = db.WorkPlaces.FirstOrDefault(x => x.WorkPlaceId == workPlace);
                columnChart = GetQuantityReportSattussByWorkedPlace(viewModel.ToList(), WorkPlaceName);
            }
            else
                columnChart = GetQuantityReportsByWorkedPlace(viewModel.ToList());

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            return View(columnChart);
        }

        public ActionResult dashboardPuestoTrabajo(DateTime? startDate, DateTime? endDate, int countryId = 0, int workPlace = 0, int situations = 0)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "Login");
            }

            if (endDate != null) endDate.Value.AddDays(1);

            if (startDate == null) startDate = DateTime.Today.AddDays(-30);
            if (endDate == null) endDate = DateTime.Today.AddDays(1);



            var reports = db.Reports
                            .Include(r => r.StatusReports)
                            .Include(r => r.WorkPlaces).OrderByDescending(x => x.CreatedDate)
                            .Where(x => x.CreatedDate >= startDate && x.CreatedDate <= endDate)
                            .ToList();

            var viewModel = Mapper.Map<IList<ReportResponseViewModel>>(reports).ToList();


            if (countryId != 0)
                viewModel = viewModel.Where(c => c.CountryId == countryId).ToList();

            Highcharts columnChart;
            //Si se filtra por centro de trabajo se debe obtener lso reportes del centro y agruparlos por estado
            if (workPlace != 0)
            {
                var WorkPlaceName = db.WorkPlaces.FirstOrDefault(x => x.WorkPlaceId == workPlace);
                columnChart = GetQuantityReportSattussByWorkedPlace(viewModel.ToList(), WorkPlaceName);
            }
            else
                columnChart = GetQuantityReportsByWorkedPlace(viewModel.ToList());

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            ViewBag.PositionId = new SelectList(db.Position, "Id", "Description");
            return View(columnChart);
        }

        public ActionResult dashboardSituacionesDetectadas(DateTime? startDate, DateTime? endDate, int countryId = 0, int workPlace = 0)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "Login");
            }

            if (endDate != null) endDate.Value.AddDays(1);

            if (startDate == null) startDate = DateTime.Today.AddDays(-30);
            if (endDate == null) endDate = DateTime.Today.AddDays(1);



            var reports = db.Reports
                            .Include(r => r.StatusReports)
                            .Include(r => r.WorkPlaces).OrderByDescending(x => x.CreatedDate)
                            .Where(x => x.CreatedDate >= startDate && x.CreatedDate <= endDate)
                            .ToList();

            var viewModel = Mapper.Map<IList<ReportResponseViewModel>>(reports).ToList();


            if (countryId != 0)
                viewModel = viewModel.Where(c => c.CountryId == countryId).ToList();

            Highcharts columnChart;
            //Si se filtra por centro de trabajo se debe obtener lso reportes del centro y agruparlos por estado
            if (workPlace != 0)
            {
                var WorkPlaceName = db.WorkPlaces.FirstOrDefault(x => x.WorkPlaceId == workPlace);
                columnChart = GetQuantityReportSattussByWorkedPlace(viewModel.ToList(), WorkPlaceName);
            }
            else
                columnChart = GetQuantityReportsByWorkedPlace(viewModel.ToList());

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            ViewBag.SituationsId = new SelectList(db.Situations, "Id", "Description");
            return View(columnChart);
        }

        public ActionResult dashboardOtrosFactores(DateTime? startDate, DateTime? endDate, int countryId = 0, int workPlace = 0)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "Login");
            }

            if (endDate != null) endDate.Value.AddDays(1);

            if (startDate == null) startDate = DateTime.Today.AddDays(-30);
            if (endDate == null) endDate = DateTime.Today.AddDays(1);



            var reports = db.Reports
                            .Include(r => r.StatusReports)
                            .Include(r => r.WorkPlaces).OrderByDescending(x => x.CreatedDate)
                            .Where(x => x.CreatedDate >= startDate && x.CreatedDate <= endDate)
                            .ToList();

            var viewModel = Mapper.Map<IList<ReportResponseViewModel>>(reports).ToList();


            if (countryId != 0)
                viewModel = viewModel.Where(c => c.CountryId == countryId).ToList();

            Highcharts columnChart;
            //Si se filtra por centro de trabajo se debe obtener lso reportes del centro y agruparlos por estado
            if (workPlace != 0)
            {
                var WorkPlaceName = db.WorkPlaces.FirstOrDefault(x => x.WorkPlaceId == workPlace);
                columnChart = GetQuantityReportSattussByWorkedPlace(viewModel.ToList(), WorkPlaceName);
            }
            else
                columnChart = GetQuantityReportsByWorkedPlace(viewModel.ToList());

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            ViewBag.FactorId = new SelectList(db.Factors, "Id", "Description");
            return View(columnChart);
        }

        private static Highcharts GetQuantityReportsByWorkedPlace(List<ReportResponseViewModel> viewModel)
        {
            var reportsByCountry = viewModel.
                                        GroupBy(c => c.WorkPlace, (a, b) => new
                                        {
                                            Key = a,
                                            Lenght = b.Count()
                                        }).ToList();

            string[] Categories = new string[reportsByCountry.Count()];
            object[] Values = new object[reportsByCountry.Count()];
            for (int i = 0; i < Categories.Count(); i++)
            {
                Categories[i] = reportsByCountry[i].Key;
                Values[i] = reportsByCountry[i].Lenght;
            }

            Highcharts columnChart = new Highcharts("columnchart");
            columnChart.InitChart(new Chart()
            {
                Type = ChartTypes.Column,
                BackgroundColor = new BackColorOrGradient(Color.AliceBlue),
                Style = "fontWeight: 'bold', fontSize: '15px'",
                BorderColor = Color.LightBlue,
                BorderRadius = 0,
                BorderWidth = 2
            });
            columnChart.SetTitle(new Title()
            {
                Text = "Centros de trabajo"
            });
            columnChart.SetSubtitle(new Subtitle()
            {
                Text = "Reportes SAR Por centro de trabajo"
            });
            columnChart.SetXAxis(new XAxis()
            {
                Type = AxisTypes.Linear,
                Title = new XAxisTitle() { Text = "Centros de Trabajo", Style = "fontWeight: 'bold', fontSize: '15px'" },
            });
            columnChart.SetYAxis(new YAxis()
            {
                Title = new YAxisTitle()
                {
                    Text = "Reportes",
                    Style = "fontWeight: 'bold', fontSize: '17px'"
                },
                ShowFirstLabel = true,
                ShowLastLabel = true,
                Min = 0
            });
            columnChart.SetLegend(new Legend
            {
                Enabled = true,
                BorderColor = Color.CornflowerBlue,
                BorderRadius = 6,
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
            });

            Series[] series = new Series[reportsByCountry.Count()];
            for (int i = 0; i < series.Length; i++)
            {
                series[i] = new Series()
                {
                    Name = reportsByCountry[i].Key,
                    Data = new Data(new object[] { Values[i] })
                };
            }

            columnChart.SetSeries(series);
            return columnChart;
        }
        private static Highcharts GetQuantityReportSattussByWorkedPlace(List<ReportResponseViewModel> viewModel, WorkPlaces workPlaceName)
        {
            var reportsByCountry = viewModel.
                                        GroupBy(c => c.Status, (a, b) => new
                                        {
                                            Key = a,
                                            Lenght = b.Count()
                                        }).ToList();

            string[] Categories = new string[reportsByCountry.Count()];
            object[] Values = new object[reportsByCountry.Count()];
            for (int i = 0; i < Categories.Count(); i++)
            {
                Categories[i] = reportsByCountry[i].Key;
                Values[i] = reportsByCountry[i].Lenght;
            }

            Highcharts columnChart = new Highcharts("columnchart");
            columnChart.InitChart(new Chart()
            {
                Type = ChartTypes.Column,
                BackgroundColor = new BackColorOrGradient(Color.AliceBlue),
                Style = "fontWeight: 'bold', fontSize: '15px'",
                BorderColor = Color.LightBlue,
                BorderRadius = 0,
                BorderWidth = 2
            });
            columnChart.SetTitle(new Title()
            {
                Text = "OBRA: " + workPlaceName.Name ?? ""
            });
            columnChart.SetSubtitle(new Subtitle()
            {
                Text = "Reportes SAR Por centro de trabajo"
            });
            columnChart.SetXAxis(new XAxis()
            {
                Type = AxisTypes.Linear,
                Title = new XAxisTitle() { Text = "Centros de Trabajo", Style = "fontWeight: 'bold', fontSize: '15px'" },
            });
            columnChart.SetYAxis(new YAxis()
            {
                Title = new YAxisTitle()
                {
                    Text = "Reportes",
                    Style = "fontWeight: 'bold', fontSize: '17px'"
                },
                ShowFirstLabel = true,
                ShowLastLabel = true,
                Min = 0
            });
            columnChart.SetLegend(new Legend
            {
                Enabled = true,
                BorderColor = Color.CornflowerBlue,
                BorderRadius = 6,
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
            });

            Series[] series = new Series[reportsByCountry.Count()];
            for (int i = 0; i < series.Length; i++)
            {
                series[i] = new Series()
                {
                    Name = reportsByCountry[i].Key,
                    Data = new Data(new object[] { Values[i] })
                };
            }

            columnChart.SetSeries(series);
            return columnChart;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult adminProject()
        {
            ViewBag.Message = "Admin page.";
            return View();
        }
        public ActionResult adminUser()
        {
            ViewBag.Message = "Admin page.";
            return View();
        }

        public ActionResult adminTables()
        {
            //if (Session["UserName"] == null)
            //{
            //    return RedirectToAction("login", "Login");
            //}

            ViewBag.Message = "Admin page.";
            return View();
        }

        public ActionResult GetCountriesController()
        {
            return RedirectToAction("Index", "Countries");
        }

        public ActionResult GetCategoriasController()
        {
            return RedirectToAction("Index", "Categories");
        }

        public ActionResult CerrarSesion()
        {
            Session["UserId"] = 0;
            Session["UserName"] = null;
            Session["Rol"] = 0;
            return RedirectToAction("login", "Login");
        }

        public JsonResult GetData(int pais = 0, int obra = 0, DateTime? desde = null, DateTime? hasta = null)
        {
            if (hasta != null) hasta.Value.AddDays(1);

            if (desde == null) desde = DateTime.Today.AddDays(-30);
            if (hasta == null) hasta = DateTime.Today.AddDays(1);



            var reports = db.Reports
                            .Include(r => r.StatusReports)
                            .Include(r => r.WorkPlaces).OrderByDescending(x => x.CreatedDate)
                            .Where(x => x.CreatedDate >= desde && x.CreatedDate <= hasta)
                            .ToList();

            if (obra != 0)
                reports = reports.Where(c => c.WorkPlaceId == obra).ToList();

            var viewModel = Mapper.Map<IList<ReportResponseViewModel>>(reports).ToList();


            if (pais != 0)
                viewModel = viewModel.Where(c => c.CountryId == pais).ToList();

            var results = viewModel.GroupBy(
                                        p => p.WorkPlace,
                                        p => p.StatusId,
                                        (key, g) => new { WorkPlace = key, Status = g.ToList() });

            List<Dashboard_1> data = new List<Dashboard_1>();
            foreach (var item in results)
            {
                data.Add(new Dashboard_1() { Key = item.WorkPlace, Reportes = item.Status.Count, Porcentaje = (Convert.ToDouble(Convert.ToDecimal(item.Status.Count(x => x == 1004)) / Convert.ToDecimal(item.Status.Count)))*1  });
            }
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDataSituation(int pais = 0, int situation = 0, DateTime? desde = null, DateTime? hasta = null)
        {
            if (hasta != null) hasta.Value.AddDays(1);

            if (desde == null) desde = DateTime.Today.AddDays(-30);
            if (hasta == null) hasta = DateTime.Today.AddDays(1);



            var reports = db.Reports
                            .Include(r => r.StatusReports)
                            .Include(r => r.Situations)
                            .Include(r => r.WorkPlaces).OrderByDescending(x => x.CreatedDate)
                            .Where(x => x.CreatedDate >= desde && x.CreatedDate <= hasta)
                            .ToList();

            if (situation != 0)
                reports = reports.Where(c => c.SituationId == situation).ToList();

            var viewModel = Mapper.Map<IList<ReportResponseViewModel>>(reports).ToList();


            if (pais != 0)
                viewModel = viewModel.Where(c => c.CountryId == pais).ToList();

            var results = viewModel.GroupBy(
                                        p => p.Situation,
                                        (key, g) => new { Situation = key, Result = g.ToList() });

            List<Dashboard_1> data = new List<Dashboard_1>();
            foreach (var item in results)
            {
                data.Add(new Dashboard_1() { Key = item.Situation, Reportes = item.Result.Count, Porcentaje = (Convert.ToDouble(Convert.ToDecimal(item.Result.Count(x => x.StatusId == 1004)) / Convert.ToDecimal(item.Result.Count))) * 100 });
            }
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDataPosition(int pais = 0, int obra = 0, DateTime? desde = null, DateTime? hasta = null)
        {
            if (hasta != null) hasta.Value.AddDays(1);

            if (desde == null) desde = DateTime.Today.AddDays(-30);
            if (hasta == null) hasta = DateTime.Today.AddDays(1);



            var reports = db.Reports
                            .Include(r => r.StatusReports)
                            .Include(r => r.Accounts)
                            .Include(r => r.WorkPlaces).OrderByDescending(x => x.CreatedDate)
                            .Where(x => x.CreatedDate >= desde && x.CreatedDate <= hasta)
                            .ToList();

            var positions = db.Position.ToList();


            if (obra != 0)
                reports = reports.Where(c => c.WorkPlaceId == obra).ToList();

            foreach (var item in reports)
            {
                item.Accounts.Position = positions.FirstOrDefault(x => x.Id == item.Accounts.PositionId);
            }

            var viewModel = Mapper.Map<IList<ReportResponseViewModel>>(reports).ToList();


            if (pais != 0)
                viewModel = viewModel.Where(c => c.CountryId == pais).ToList();

            var results = viewModel.GroupBy(
                                        p => p.Position,
                                        (key, g) => new { Position = key, Result = g.ToList() });

            List<Dashboard_1> data = new List<Dashboard_1>();
            foreach (var item in results)
            {
                data.Add(new Dashboard_1() { Key = item.Position, Reportes = item.Result.Count, Porcentaje = (Convert.ToDouble(Convert.ToDecimal(item.Result.Count(x => x.StatusId == 1004)) / Convert.ToDecimal(item.Result.Count))) * 100 });
            }
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDataFactor(int pais = 0, int obra = 0, DateTime? desde = null, DateTime? hasta = null)
        {
            if (hasta != null) hasta.Value.AddDays(1);

            if (desde == null) desde = DateTime.Today.AddDays(-30);
            if (hasta == null) hasta = DateTime.Today.AddDays(1);



            var reports = db.Reports
                            .Include(r => r.StatusReports)
                            .Include(r => r.WorkPlaces).OrderByDescending(x => x.CreatedDate)
                            .Where(x => x.CreatedDate >= desde && x.CreatedDate <= hasta)
                            .ToList();

            if (obra != 0)
                reports = reports.Where(c => c.WorkPlaceId == obra).ToList();

            var viewModel = Mapper.Map<IList<ReportResponseViewModel>>(reports).ToList();


            if (pais != 0)
                viewModel = viewModel.Where(c => c.CountryId == pais).ToList();

            var results = viewModel.GroupBy(
                                        p => p.Factor,
                                        (key, g) => new { Factor = key, Result = g.ToList() });

            List<Dashboard_1> data = new List<Dashboard_1>();
            foreach (var item in results)
            {
                data.Add(new Dashboard_1() { Key = item.Factor, Reportes = item.Result.Count, Porcentaje = (Convert.ToDouble(Convert.ToDecimal(item.Result.Count(x => x.StatusId == 1004)) / Convert.ToDecimal(item.Result.Count))) * 100 });
            }
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }

    }

    public class Dashboard_1
    {
        public string Key { get; set; }
        public int Reportes { get; set; }
        [JsonPropertyName("Porcentaje Cierres")]
        public double Porcentaje { get; set; }
    }
}
