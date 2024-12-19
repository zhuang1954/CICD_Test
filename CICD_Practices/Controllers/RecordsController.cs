using Microsoft.AspNetCore.Mvc;

namespace CICD_Practices.Controllers;

public class RecordsController : Controller
{
    // Index (Read All)
    public ActionResult Index(string Name = "")
    {
        if (Name == "")
        {
            var records1 = RecordManager.GetAll();

            return View(records1);
        }

        var records = RecordManager.GetAll().Where(x => x.Name.Contains(Name)).ToList();
        return View(records);
    }

    // Details (Read Single)
    public ActionResult Details(int id)
    {
        var record = RecordManager.GetById(id);
        if (record == null)
            throw new Exception();
        return View(record);
    }

    // Create (GET)
    public ActionResult Create()
    {
        return View();
    }

    // Create (POST)
    [HttpPost]
    public ActionResult Create(string name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            RecordManager.Create(name);
            return RedirectToAction("Index");
        }

        return View();
    }

    // Edit (GET)
    public ActionResult Edit(int id)
    {
        var record = RecordManager.GetById(id);
        if (record == null)
            throw new Exception();
        return View(record);
    }

    // Edit (POST)
    [HttpPost]
    public ActionResult Edit(int id, string name)
    {
        RecordManager.Update(id, name);
        return RedirectToAction("Index");
    }

    // Delete (GET)
    public ActionResult Delete(int id)
    {
        var record = RecordManager.GetById(id);
        if (record == null)
            throw new Exception();
        return View(record);
    }

    // Delete (POST)
    [HttpPost]
    [ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        RecordManager.Delete(id);
        return RedirectToAction("Index");
    }
}