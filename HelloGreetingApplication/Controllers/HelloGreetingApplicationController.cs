using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using NLog;


namespace HelloGreetingApplication.Controllers;

/// <summary>
/// Class providing API for HelloGreetingg
/// </summary>

[ApiController]
[Route("[controller]")]
public class HelloGreetingApplicationController : ControllerBase
{

    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    IGreetingBL _greetingBL;

    public HelloGreetingApplicationController(IGreetingBL greetingBL)
    {
        _greetingBL = greetingBL;
    }

    [HttpGet("custom")]
    public IActionResult GreetingMessage(string? firstName, string? lastName)
    {
        string result = _greetingBL.GreetingMessage(firstName, lastName);
        ResponseModel<string> responseModel = new ResponseModel<string>();
        responseModel.Success = true;
        responseModel.Message = "Greeting Message Executed";
        responseModel.Data = result;
        logger.Info($"Greeting fetched {result}");
        return Ok(responseModel);
    }

    /// <summary>
    /// Get method to get the Greeting message
    /// </summary>
    /// <returns>"Hello, World!</returns>

    [HttpGet]
    public IActionResult Get() {
        ResponseModel<string> responseModel = new ResponseModel<string>();
        responseModel.Success = true;
        responseModel.Message = "Hello to Greeting App API Endpoint";
        responseModel.Data = "Hello World!";
        logger.Info("Get method executed");
        return Ok(responseModel);

    }

    [HttpPost]
    public IActionResult Post(RequestModel requestModel) {
        ResponseModel<string> responseModel = new ResponseModel<string>();
        responseModel.Success = true;
        responseModel.Message = "Request received successfully";
        responseModel.Data = $"Key: {requestModel.key}, Value: {requestModel.value}";
        logger.Info("Post method executed");
        return Ok(responseModel);

    }

    /// <summary>
    /// Put method to update a resource
    /// </summary>
    /// <returns>Success message with updated data</returns>

    [HttpPut]
    public IActionResult Put(RequestModel requestModel)
    {
        ResponseModel<string> responseModel = new ResponseModel<string>();
        responseModel.Success = true;
        responseModel.Message = "Data updated successfully";
        responseModel.Data = $"Updated Key: {requestModel.key}, Updated Value: {requestModel.value}";
        logger.Info("Post method executed");
        return Ok(responseModel);
    }


    [HttpPatch]
    public IActionResult Patch(RequestModel requestModel)
    {
        ResponseModel<string> responseModel = new ResponseModel<string>();
        responseModel.Success = true;
        responseModel.Message = "Data patched successfully";
        responseModel.Data = $"Patched Key: {requestModel.key}, Patched Value: {requestModel.value}";
        logger.Info("Patch method executed");
        return Ok(responseModel);
    }

    [HttpDelete]
    public IActionResult Delete(RequestModel requestModel)
    {
        ResponseModel<string> responseModel = new ResponseModel<string>();
        responseModel.Success = true;
        responseModel.Message = "Data deleted successfully";
        responseModel.Data = $"Deleted Key: {requestModel.key}";
        logger.Info("Deleted method executed");
        return Ok(responseModel);
    }

}
