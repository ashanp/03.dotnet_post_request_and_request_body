using System.Diagnostics;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Run(async (HttpContext context) => {

context.Response.Headers.Add("Content-type","text/html");

var regMethod = context.Request.Method;
var reqHeaders = context.Request.Headers;
var userIdkey = reqHeaders.Keys.FirstOrDefault(key => key.Equals("ID"));
var userIdvalue = context.Request.Headers["ID"];

await context.Response.WriteAsync($"<div> Key: {userIdkey} </div>");
await context.Response.WriteAsync($"<div> value: {userIdvalue} </div>");

// this way we will not be able to accsess the data. so we need to use a streamreader 
var requestBody = context.Request.Body;
await context.Response.WriteAsync($"<div> body: {requestBody} </div>");

// this is how we access a stream to get the data using stream reader
String requestBodyString;
using(StreamReader reader = new StreamReader(context.Request.Body)){
    requestBodyString = await reader.ReadToEndAsync();
    await context.Response.WriteAsync($"<div> the body is : {requestBodyString} </div>");
}

    // using dictionary we can decode the key pair values passed as body in proper format
Dictionary<string, StringValues> dict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(requestBodyString);
        foreach (var item in dict)
        {
            await context.Response.WriteAsync($"<div>response: {item}\n</div>");
        }
});
app.Run();
