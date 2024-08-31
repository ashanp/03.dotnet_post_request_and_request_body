using System.Diagnostics;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;

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

  
});
app.Run();
