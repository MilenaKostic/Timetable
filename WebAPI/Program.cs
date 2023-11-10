using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using Shared.Models;
using Shared.DTO;

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
async Task<List<Calendar>> GetCalendars(DataContext context) => await context.calendars.ToListAsync();


app.MapPost("/Calendar", async (DataContext context, Calendar item) =>
{
    context.calendars.Add(item);
    await context.SaveChangesAsync();
    return Results.Ok(await GetCalendars(context));
});


app.MapGet("/Calendar", async (DataContext context) =>
await context.calendars.ToListAsync()); 

app.MapGet("/Calendar/{Id}", async (DataContext context, int Id) => 
    await context.calendars.FindAsync(Id) is Calendar item ? Results.Ok(item) : Results.NotFound("CALENDAR NOT FOUND"));

app.MapPut("/Calendar/{Id}", async (DataContext context, Calendar item, int Id) =>
{
    var calendarItem = await context.calendars.FindAsync(Id);
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

    context.calendars.Update(calendarItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetCalendars(context));
});

app.MapDelete("/Calendar/{Id}", async (DataContext context, int Id) =>
{
    var calendarItem = await context.calendars.FindAsync(Id);
    if (calendarItem == null)
        return Results.NotFound("Calendar not found");

    context.calendars.Remove(calendarItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetCalendars(context));
});

//CALENDAR DATES 
async Task<List<CalendarDate>> GetCalendarDates(DataContext context) => await context.calendarDates.ToListAsync();

app.MapPost("/CalendarDate", async (DataContext context, CalendarDate item) =>
{
    context.calendarDates.Add(item);
    await context.SaveChangesAsync();
    return Results.Ok(GetCalendarDates(context));
});

app.MapGet("/CalendarDate", async (DataContext context) =>
    await context.calendarDates.ToListAsync());

app.MapGet("/CalendarDate/{Id}", async (DataContext context, int Id) =>
    await context.calendarDates.FindAsync(Id) is CalendarDate item ? Results.Ok(item) : Results.NotFound("CalendarDate not found")
);

app.MapPut("/CalendarDate/{Id}", async (DataContext context, CalendarDate item, int Id) =>
{
    var calendarDateItem = await context.calendarDates.FindAsync(Id);
    if (calendarDateItem == null)
       return Results.NotFound("CalendarDate not found");

    calendarDateItem.date = item.date;
    calendarDateItem.serviceId = item.serviceId; 

    context.calendarDates.Update(calendarDateItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetCalendarDates(context));
    
});

app.MapDelete("/CalendarDate/{Id}", async (DataContext context, int Id) =>
{ 
    var calendarDateItem = await context.calendarDates.FindAsync(Id);
    if (calendarDateItem == null)
        return Results.NotFound("CalendarDate not found");

    context.calendarDates.Remove(calendarDateItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetCalendarDates(context));


});

//ROUTE 
async Task<List<Shared.Models.Route>> GetRoutes(DataContext context) => await context.routes.ToListAsync();

app.MapPost("/Route", async(DataContext context, Shared.Models.Route item) =>
{
    context.routes.Add(item);
    await context.SaveChangesAsync();
    return Results.Ok(await GetRoutes(context));

});

app.MapGet("/Route", async (DataContext context) =>
    await context.routes.ToListAsync());

app.MapGet("/Route/{Id}", async (DataContext context, int Id) =>
    await context.routes.FindAsync(Id) is Shared.Models.Route item ? Results.Ok(item) : Results.NotFound("Route not found")
);

app.MapPut("Route/{Id}", async (DataContext context, Shared.Models.Route item,  int Id) =>
{
    var routeItem = await context.routes.FindAsync(Id);

    if (routeItem == null)
        return Results.NotFound("Result not found");

    routeItem.routeName = item.routeName;
    routeItem.routeColor = item.routeColor;

    await context.SaveChangesAsync();
    return Results.Ok(await GetRoutes(context)); 
});

app.MapDelete("/Route/{Id}", async (DataContext context, int Id) =>
{
   var routeItem = await context.routes.FindAsync(Id);

    if (routeItem == null)
       return Results.NotFound("Route not found ");

    context.routes.Remove(routeItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetRoutes(context));

});

//TRIP
async Task<List<Trip>> GetTrips(DataContext context) => await context.trips.ToListAsync();

app.MapPost("/Trip", async (DataContext context, Trip item) =>
{
    context.trips.Add(item);
    await context.SaveChangesAsync();
    return Results.Ok(await GetTrips(context));
}); 

app.MapGet("/Trip", async(DataContext context)=>
    await context.trips.ToListAsync());

app.MapGet("/Trip/{Id}", async (DataContext context, int Id) =>
    await context.trips.FindAsync(Id) is Trip item ? Results.Ok(item) : Results.NotFound("Trip not found")
);

app.MapPut("/Trip/{Id}", async (DataContext context, Trip item, int Id) =>
{
    var tripItem = await context.trips.FindAsync(Id);

    if (tripItem == null)
        return Results.NotFound("Trip not found");

    tripItem.routeId = item.routeId;
    tripItem.serviceId = item.serviceId;

    context.trips.Update(tripItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetTrips(context));

});

app.MapDelete("/Trip/{Id}", async (DataContext context, int Id) =>
{
    var tripItem = await context.trips.FindAsync(Id);

    if (tripItem == null)
        return Results.NotFound("Trip not found");

    context.trips.Remove(tripItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetTrips(context));
});

//STOP

async Task<List<Stop>> GetStops(DataContext context) => await context.stops.ToListAsync();

app.MapPost("/Stop", async (DataContext context, Stop item) =>
{
    context.stops.Add(item);
    await context.SaveChangesAsync();
    return Results.Ok(GetStops(context));
});

app.MapGet("/Stop", async (DataContext context) =>
    await context.stops.ToListAsync());

app.MapGet("/Stop/{Id}", async (DataContext context, int Id) =>
    await context.stops.FindAsync(Id) is Stop item ? Results.Ok(item) : Results.NotFound("Stop not found")
);

app.MapPut("/Stop/{Id}", async (DataContext context, Stop item, int Id) =>
{
    var stopItem = await context.stops.FindAsync(Id);
    if (stopItem == null)
        return Results.NotFound("Stop not found");

    stopItem.stopName = item.stopName;
    stopItem.stopLon = item.stopLon;
    stopItem.stopLat = item.stopLat;

    context.stops.Update(stopItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetStops(context));

});

app.MapDelete("/Stop/{Id}", async (DataContext context, int Id) =>
{
    var stopItem = await context.stops.FindAsync(Id);
    if (stopItem == null)
        return Results.NotFound("Stop not found");

    context.stops.Remove(stopItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetStops(context));


});



//STOP TIMES 
async Task<List<StopTime>> GetStopTimes(DataContext context) => await context.stopTimes.ToListAsync();

app.MapPost("StopTimes", async (DataContext context, StopTime item) =>
{ 
    context.stopTimes.Add(item);
    await context.SaveChangesAsync();
    return Results.Ok(GetStopTimes(context));
});

app.MapGet("StopTimes", async (DataContext context) =>
    await context.stopTimes.ToListAsync()
);

app.MapGet("StopTimes/{Id}", async (DataContext context, int Id) =>
    await context.stopTimes.FindAsync(Id) is StopTime item ? Results.Ok(item) : Results.NotFound("Stop time not found"));

app.MapPut("StopTimes/{Id}", async (DataContext context, int Id, StopTime item) =>
{
    var StopTimeItem = await context.stopTimes.FindAsync(Id);

    if (StopTimeItem == null)
        return Results.NotFound("Stop time not found");

    StopTimeItem.stopId = item.stopId;
    StopTimeItem.stopSequence = item.stopSequence;

    context.stopTimes.Update(StopTimeItem);
    await context.SaveChangesAsync();
    return Results.Ok(GetStopTimes(context));
});

app.MapDelete("StopTimes/{Id}", async (DataContext context, int Id) =>  
{
    var StopTimeItem = await context.stopTimes.FindAsync(Id);

    if (StopTimeItem == null)
        return Results.NotFound("Stop time not found");

    context.stopTimes.Remove(StopTimeItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetStopTimes(context));

});

app.Run();

//internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}