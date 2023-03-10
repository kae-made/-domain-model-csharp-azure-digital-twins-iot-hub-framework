// Copyright (c) Knowledge & Experience. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using Kae.DomainModel.CSharp.Utility.Application.WebAPIAppDomainModelViewerForADT.Controllers;
using Kae.DomainModel.CSharp.Utility.Application.WebAPIAppDomainModelViewerForADT.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<DomainModelStateHub>("stateHub");

DomainModelController.DomainModelAdaptorDllPath = builder.Configuration.GetSection("DomainModelAdaptor").GetSection("Dll").Value;
DomainModelController.HubUrl = builder.Configuration.GetSection("SignalR").GetSection("Url").Value;
DomainModelController.AppConfig = builder.Configuration;

app.Run();
