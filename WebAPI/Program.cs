using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseHttpsRedirection();
 
//CALENDAR 
async Task<List<Calendar>> GetCalendars(DataContext context) => await context.Calendars.ToListAsync();


app.MapPost("Add/Calendar", async (DataContext context, Calendar item) =>
{
    context.Calendars.Add(item);
    await context.SaveChangesAsync();
    return Results.Ok(await GetCalendars(context));
});


app.MapGet("/Calendar", async (DataContext context) =>
await context.Calendars.ToListAsync()); 

app.MapGet("/Calendar/{serviceId}", async (DataContext context, int serviceId) => await context.Calendars.FindAsync(serviceId) is Calendar item? Results.Ok(item) : Results.NotFound("CALENDAR NOT FOUND")).WithName("GetCalendarById");

app.MapPut("/Calendar/{serviceId}", async (DataContext context, Calendar item, int serviceId) =>
{
    var calendarItem = await context.Calendars.FindAsync(serviceId);
    if (calendarItem == null)
        return Results.NotFound("Calendar not found");

    calendarItem.monday = item.monday;
    calendarItem.tuesday = item.tuesday;
    calendarItem.wednesday = item.wednesday;
    calendarItem.thursday = item.thursday;
    calendarItem.friday = item.friday;
    calendarItem.saturday = item.saturday;
    calendarItem.sunday = item.sunday;
    calendarItem.startDate = item.startDate;
    calendarItem.endDate = item.endDate;

    context.Calendars.Update(calendarItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetCalendars(context));
});

app.MapDelete("/Calendar/{serviceId}", async (DataContext context, int serviceId) =>
{
    var calendarItem = await context.Calendars.FindAsync(serviceId);
    if (calendarItem == null)
        return Results.NotFound("Calendar not found");

    context.Remove(calendarItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetCalendars(context));
});

//CALENDAR DATES 
async Task<List<CalendarDate>> GetCalendarDates(DataContext context) => await context.CalendarDates.ToListAsync();

app.MapPost("/CalendarDate", async (DataContext context, CalendarDate item) =>
{
    context.CalendarDates.Add(item);
    await context.SaveChangesAsync();
    return Results.Ok(GetCalendarDates(context));
});

app.MapGet("/CalendarDate", async (DataContext context) =>
    await context.CalendarDates.ToListAsync());

app.MapGet("/CalendarDate/{serviceId}", async (DataContext context, int serviceId) =>
    await context.CalendarDates.FindAsync(serviceId) is CalendarDate item ? Results.Ok(item) : Results.NotFound("CalendarDate not found")
);

app.MapPut("/CalendarDate/{serviceId}", async (DataContext context, CalendarDate item, int serviceId) =>
{
    var calendarDateItem = await context.CalendarDates.FindAsync(serviceId);
    if (calendarDateItem == null)
       return Results.NotFound("CalendarDate not found");

    calendarDateItem.date = item.date;

    context.CalendarDates.Update(calendarDateItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetCalendarDates(context));
    
});

app.MapDelete("/CalendarDate/{serviceDate}", async (DataContext context, int serviceId) =>
{ 
    var calendarDateItem = await context.CalendarDates.FindAsync(serviceId);
    if (calendarDateItem == null)
        return Results.NotFound("CalendarDate not found");

    context.CalendarDates.Remove(calendarDateItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetCalendarDates(context));


});

//ROUTE 
async Task<List<WebAPI.Models.Route>> GetRoutes(DataContext context) => await context.Routes.ToListAsync();

app.MapPost("/Route", async(DataContext context, WebAPI.Models.Route item) =>
{
    context.Routes.Add(item);
    await context.SaveChangesAsync();
    return Results.Ok(await GetRoutes(context));

});

app.MapGet("/Route", async (DataContext context) =>
{
    await context.Routes.ToListAsync();
});

app.MapGet("/Route/{routeId}", async (DataContext context, int routeId) =>
    await context.Routes.FindAsync(routeId) is WebAPI.Models.Route item ? Results.Ok(item) : Results.NotFound("Route not found")
);

app.MapPut("Route/{routeId}", async (DataContext context, WebAPI.Models.Route item,  int routeId) =>
{
    var routeItem = await context.Routes.FindAsync(routeId);

    if (routeItem == null)
        return Results.NotFound("Result not found");

    routeItem.routeName = item.routeName;
    routeItem.routeColor = item.routeColor;

    await context.SaveChangesAsync();
    return Results.Ok(await GetRoutes(context)); 
});

app.MapDelete("/Route/{routeId}", async (DataContext context, int routeId) =>
{
   var routeItem = await context.Routes.FindAsync(routeId);

    if (routeItem == null)
       return Results.NotFound("Route not found ");

    context.Routes.Remove(routeItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetRoutes(context));

});

//TRIP
async Task<List<Trip>> GetTrips(DataContext context) => await context.Trips.ToListAsync();

app.MapPost("Add/Trip", async (DataContext context, Trip item) =>
{
    context.Trips.Add(item);
    await context.SaveChangesAsync();
    return Results.Ok(await GetTrips(context));
}); 

app.MapGet("/Trip", async(DataContext context)=>
{
    await context.Trips.ToListAsync();
});

app.MapGet("/Trip/{tripId}", async (DataContext context, int tripId) =>
    await context.Trips.FindAsync(tripId) is Trip item ? Results.Ok(item) : Results.NotFound("Trip not found")
);

app.MapPut("/Trip/{tripId}", async (DataContext context, Trip item, int tripId) =>
{
    var tripItem = await context.Trips.FindAsync(tripId);

    if (tripItem == null)
        return Results.NotFound("Trip not found");

    tripItem.routeId = item.routeId;
    tripItem.serviceId = item.serviceId;

    context.Trips.Update(tripItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetTrips(context));

});

app.MapDelete("/Trip/{tripId}", async (DataContext context, int tripId) =>
{
    var tripItem = await context.Trips.FindAsync(tripId);

    if (tripItem == null)
        return Results.NotFound("Trip not found");

    context.Trips.Remove(tripItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetTrips(context));
});

//STOP TIMES 
async Task<List<StopTime>> GetStopTimes(DataContext context) => await context.StopTimes.ToListAsync();

app.MapPost("StopTimes", async (DataContext context, StopTime item) =>
{ 
    context.StopTimes.Add(item);
    await context.SaveChangesAsync();
    return Results.Ok(GetStopTimes(context));
});

app.MapGet("StopTimes", async (DataContext context) =>
    await context.StopTimes.ToListAsync()
);

app.MapGet("StopTimes", async (DataContext context, int tripId) =>
    await context.StopTimes.FindAsync(tripId) is StopTime item ? Results.Ok(item) : Results.NotFound("Stop time not found"));

app.MapPut("StopTimes/{tripId}", async (DataContext context, int tripId, StopTime item) =>
{
    var StopTimeItem = await context.StopTimes.FindAsync(tripId);

    if (StopTimeItem == null)
        return Results.NotFound("Stop time not found");

    StopTimeItem.stopId = item.stopId;
    StopTimeItem.stopSequence = item.stopSequence;

    context.StopTimes.Update(StopTimeItem);
    await context.SaveChangesAsync();
    return Results.Ok(GetStopTimes(context));
});

app.MapDelete("StopTimes/{tripId}", async (DataContext context, int tripId) =>
{
    var StopTimeItem = await context.StopTimes.FindAsync(tripId);

    if (StopTimeItem == null)
        return Results.NotFound("Stop time not found");

    context.StopTimes.Remove(StopTimeItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetStopTimes(context));

});

app.Run();

//internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}