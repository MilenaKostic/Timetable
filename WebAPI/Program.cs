using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using Shared.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shared.DTO.Route;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(c =>
{
    c.TagActionsBy(d =>
    {
        var rootSegment = d.RelativePath?
            .Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
            .FirstOrDefault() ?? "Home";
        return new List<string> { rootSegment! };
    });
});

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
{
    var _calendars = await context.calendars.ToListAsync();

    var _calendarsDTO = _calendars.Select(row => new CalendarGetBasicDTO()
    {
        Id = row.Id,
        Monday = row.monday,
        Tuesday = row.tuesday,
        Wednesday = row.wednesday,
        Thursday = row.thursday,
        Friday = row.friday,
        Saturday = row.saturday,
        Sunday = row.sunday
    }).ToList();

    return Results.Ok(_calendarsDTO); 
});

app.MapGet("/Calendar/{Id}", async (DataContext context, int Id) =>
{
    var _calendar = await context.calendars.FirstOrDefaultAsync(c => c.Id == Id);

    if (_calendar == null)
        return Results.NotFound("Route not found");

    var _calendarDTO = new CalendarGetDTO()
    {
        Id = _calendar.Id,
        Monday = _calendar.monday,
        Tuesday = _calendar.thursday,
        Wednesday = _calendar.wednesday,
        Thursday = _calendar.thursday,
        Friday = _calendar.friday,
        Saturday = _calendar.saturday,
        Sunday = _calendar.sunday,
        StartDate = _calendar.startDate,
        EndDate = _calendar.endDate
    };

    return Results.Ok(_calendarDTO); 
    

});    

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
{
    var _calendarDates = await context.calendarDates.ToListAsync();

    var _calendarDatesDTO = _calendarDates.Select(row => new CalendarDateGetBasicDTO()
    {
        Id = row.Id,
        Date = row.date
    }).ToList();

    return Results.Ok(_calendarDatesDTO);     
    
});

app.MapGet("/CalendarDate/{Id}", async (DataContext context, int Id) =>
{
    var _calendarDate = await context.calendarDates.FirstOrDefaultAsync(c => c.Id == Id);

    if(_calendarDate == null)
        return Results.NotFound("Calendar not found");

    var _calendarDateDTO = new CalendarDateGetDTO()
    {
        Id = _calendarDate.Id,
        Date = _calendarDate.date,
        ServiceId = _calendarDate.serviceId
    };

    return Results.Ok(_calendarDateDTO); 

});

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
async Task<List<WebAPI.Models.Route>> GetRoutes(DataContext context) => await context.routes.ToListAsync();

app.MapPost("/Route", async(DataContext context, WebAPI.Models.Route item) =>
{
    context.routes.Add(item);
    await context.SaveChangesAsync();
    return Results.Ok(await GetRoutes(context));

});

app.MapGet("/Route", async (DataContext context) =>
{
    var _routes = await context.routes.ToListAsync();

    var _routesDTO = _routes.Select(row => new RouteGetBasicDTO()
    {
        Id = row.Id,
        Name = row.routeName

    }).ToList();

    return Results.Ok(_routesDTO);

});

app.MapGet("/Route/{Id}", async (DataContext context, int Id) =>
{
    var _route = await context.routes.FirstOrDefaultAsync(r => r.Id == Id);

    if (_route == null)
        return Results.NotFound("Route not found");

    var _routeDTO = new RouteGetDTO()
    {
        Id = _route.Id,
        Name = _route.routeName,
        Color = _route.routeColor
    };

    return Results.Ok(_routeDTO); 

});

app.MapPut("/Route/{Id}", async (DataContext context, WebAPI.Models.Route item,  int Id) =>
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
{
    var _trips = await context.trips.ToListAsync();

    var _tripsDTO = _trips.Select(row => new TripGetBasicDTO()
    {
        Id = row.Id

    }).ToList();

    return Results.Ok(_tripsDTO); 

});

app.MapGet("/Trip/{Id}", async (DataContext context, int Id) =>
{
    var _trip = await context.trips.FirstOrDefaultAsync(t => t.Id == Id);

    if (_trip == null)
        return Results.NotFound("Trip not found");

    var _tripDTO = new TripGetDTO()
    {
        Id = _trip.Id,
        RouteId = _trip.routeId,
        ServiceId = _trip.serviceId
    };

    return Results.Ok(_tripDTO);

});

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
{ 
    var _stops = await context.stops.ToListAsync();

    var _stopsDTO = _stops.Select(row => new StopGetBasicDTO()
    {
        Id = row.Id,
        Name = row.stopName
    }).ToList();

    return Results.Ok(_stopsDTO); 

});

app.MapGet("/Stop/{Id}", async (DataContext context, int Id) =>
{
    var _stop = await context.stops.FirstOrDefaultAsync(s => s.Id == Id);

    if (_stop == null)
        return Results.NotFound("Stop not found");

    var _stopDTO = new StopGetDTO()
    {
        Id = _stop.Id,
        Name = _stop.stopName,
        Lat = _stop.stopLat,
        Lon = _stop.stopLon
    };

    return Results.Ok(_stopDTO); 

});

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
   {
       var _stopTimes = await context.stopTimes.ToListAsync();

       var _stopTimesDTO = _stopTimes.Select(row => new StopTimeGetBasicDTO()
       {
           Id = row.Id,
           StopSequence = row.stopSequence

       }).ToList();

       return Results.Ok(_stopTimesDTO); 
    
   });

app.MapGet("StopTimes/{Id}", async (DataContext context, int Id) =>
{ 
    var _stopTime = await context.stopTimes.FirstOrDefaultAsync(s => s.Id == Id);

    if (_stopTime == null)
        return Results.NotFound("Stop time not found");

    var _stopTimeDTO = new StopTimeGetDTO()
    {
        Id = _stopTime.Id,
        StopId = _stopTime.stopId,
        StopSequence = _stopTime.stopSequence,
        TripId = _stopTime.tripId
    };

    return Results.Ok(_stopTimeDTO);

});

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
