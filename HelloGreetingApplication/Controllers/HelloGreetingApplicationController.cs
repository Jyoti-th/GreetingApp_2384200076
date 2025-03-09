using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using NLog;
using RepositoryLayer.Entity;
using RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Service;


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


    [HttpDelete("DeleteGreeting")]
    public IActionResult DeleteGreeting(int id)
    {
        var result = _greetingBL.DeleteGreeting(id);

        if (!result)
        {
            return NotFound(new { Success = false, Message = "Greeting not found!" });
        }
        logger.Info("Deleted");
        return Ok(new
        {
            Success = true,
            Message = "Greeting deleted successfully!"
        });
    }


    [HttpPut("UpdateGreeting")]
    public IActionResult UpdateGreeting(int id, string newMessage)
    {
        var result = _greetingBL.UpdateGreeting(id, newMessage);

        if (result == null)
        {
            return NotFound(new { Success = false, Message = "Greeting not found!" });
        }
        logger.Info($"Greeting Updated");
        return Ok(new
        {
            Success = true,
            Message = "Greeting updated successfully!",
            Data = result
        });
        
    }



    [HttpGet("GetAllGreetings")]
    public IActionResult GetAllGreetings()
    {
        var result = _greetingBL.GetAllGreetings();
        ResponseModel<List<UserEntity>> responseModel = new ResponseModel<List<UserEntity>>();
        responseModel.Success = true;
        responseModel.Message = "All Greetings fetched successfully!";
        responseModel.Data = result;
        logger.Info($"Greetings fetched");
        return Ok(responseModel);
    }



    [HttpGet("FindGreeting")]
    public IActionResult GetGreetingById(int id)
    {
        var result = _greetingBL.GetGreetingById(id);

        if (result == null)
        {
            return NotFound("Greeting not found!");
        }
        ResponseModel<UserEntity> responseModel = new ResponseModel<UserEntity>();
        responseModel.Success = true;
        responseModel.Message = "Greeting fetched successfully!";
        responseModel.Data = result;
        logger.Info($"Greeting fetched : {result.Message}");
        return Ok(responseModel);
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

    [HttpPost("SaveGreeting")]
    public IActionResult SaveGreetings(string message)
    {
        var result = _greetingBL.SaveGreetings(message);
        ResponseModel<UserEntity> responseModel = new ResponseModel<UserEntity>();
        responseModel.Success = true;
        responseModel.Message = "Greeting saved successfully!";
        responseModel.Data = result;
        logger.Info($"Greeting saved: {result.Message}");

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

    [HttpGet("TestException")]
    public IActionResult TestException()
    {
        throw new Exception("This is a test exception!");
    }



}
