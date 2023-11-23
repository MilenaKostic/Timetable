using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using Shared.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shared.DTO.Route;
using Shared.DTO.User;
using System;

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
//async Task<List<Calendar>> GetCalendars(DataContext context) => await context.calendars.ToListAsync();

app.MapPost("/Calendar", async (DataContext context, CalendarPostDTO item) =>
{
    var _checkExist = await context.calendars.FirstOrDefaultAsync(c => c.startDate.Equals(item.StartDate) && c.endDate.Equals(item.EndDate));

    if (_checkExist != null)
        return Results.BadRequest("Calendar already exists");

    var _newCalendar = new Calendar()
    {
        monday = item.Monday,
        tuesday = item.Tuesday,
        wednesday = item.Wednesday,
        thursday = item.Thursday,
        friday = item.Friday,
        saturday = item.Saturday,
        sunday = item.Sunday,
        startDate = item.StartDate,
        endDate = item.EndDate
    };

    context.calendars.Add(_newCalendar);
    await context.SaveChangesAsync();

    var _retVal = new CalendarDTO()
    {
        Id = _newCalendar.Id,
        Monday = _newCalendar.monday,
        Tuesday = _newCalendar.tuesday,
        Wednesday = _newCalendar.wednesday,
        Thursday = _newCalendar.thursday,
        Friday = _newCalendar.friday,
        Saturday = _newCalendar.saturday,
        Sunday = _newCalendar.sunday,
        StartDate = _newCalendar.startDate,
        EndDate = _newCalendar.endDate

    };

    return Results.Created("", _retVal); 


});

app.MapGet("/Calendar/AllCalendars", async (DataContext context) =>
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

    var _calendarDTO = new CalendarDTO()
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

app.MapPut("/Calendar/{Id}", async (DataContext context, CalendarPutDTO calendarDTO, int Id) =>
{
    var _checkExist = await context.calendars.FirstOrDefaultAsync(c => c.Id == Id);

    if (_checkExist == null)
        return Results.BadRequest("Calendar does not exists");


    _checkExist.monday = calendarDTO.Monday;
    _checkExist.tuesday = calendarDTO.Tuesday;
    _checkExist.wednesday = calendarDTO.Wednesday;
    _checkExist.thursday = calendarDTO.Thursday;
    _checkExist.friday = calendarDTO.Friday;
    _checkExist.saturday = calendarDTO.Saturday;
    _checkExist.sunday = calendarDTO.Sunday;
    _checkExist.startDate = calendarDTO.StartDate;
    _checkExist.endDate = calendarDTO.EndDate;
    

    context.calendars.Update(_checkExist);
    await context.SaveChangesAsync();

    var _retVal = new CalendarDTO()
    {
        Id = _checkExist.Id,
        Monday = _checkExist.monday,
        Tuesday = _checkExist.tuesday,
        Wednesday = _checkExist.wednesday,
        Thursday = _checkExist.thursday,
        Friday = _checkExist.friday,
        Saturday = _checkExist.saturday,
        Sunday = _checkExist.sunday,
        StartDate = _checkExist.startDate,
        EndDate = _checkExist.endDate

    };

    return Results.Ok();
});

app.MapDelete("/Calendar/{Id}", async (DataContext context, int Id) =>
{
    var calendarItem = await context.calendars.FindAsync(Id);
    if (calendarItem == null)
        return Results.NotFound("Calendar not found");

    context.calendars.Remove(calendarItem);
    await context.SaveChangesAsync();
    return Results.Ok("Successfully deleted");
});

//CALENDAR DATES 
//async Task<List<CalendarDate>> GetCalendarDates(DataContext context) => await context.calendarDates.ToListAsync();

app.MapPost("/CalendarDate", async (DataContext context, CalendarDatePostDTO item) =>
{
    var _checkExist = await context.calendarDates.FirstOrDefaultAsync(c => c.serviceId.Equals(item.ServiceId) && c.date.Equals(item.Date));

    if (_checkExist != null)
        return Results.BadRequest("Calendar date already exists");

    var _newCalendarDate = new CalendarDate()
    {
        serviceId = item.ServiceId,
        date = item.Date
    };

    context.calendarDates.Add(_newCalendarDate);
    await context.SaveChangesAsync();

    var _retValue = new CalendarDateDTO()
    {
        Id = _newCalendarDate.Id,
        ServiceId = _newCalendarDate.serviceId,
        Date = _newCalendarDate.date
    };

    return Results.Created("", _retValue);
});

app.MapGet("/CalendarDate/AllCalendarDates", async (DataContext context) =>
{
    var _calendarDates = await context.calendarDates.ToListAsync();

    var _calendarDatesDTO = _calendarDates.Select(row => new CalendarDateGetBasicDTO()
    {
        Id = row.Id,
        Date = row.date
    }).ToList();

    return Results.Ok(_calendarDatesDTO);     
    
});

app.MapGet("/CalendarDate/ById:{Id}", async (DataContext context, int Id) =>
{
    var _calendarDate = await context.calendarDates.FirstOrDefaultAsync(c => c.Id == Id);

    if(_calendarDate == null)
        return Results.NotFound("Calendar not found");

    var _calendarDateDTO = new CalendarDateDTO()
    {
        Id = _calendarDate.Id,
        Date = _calendarDate.date,
        ServiceId = _calendarDate.serviceId
    };

    return Results.Ok(_calendarDateDTO); 

});

app.MapGet("/CalendarDate/ByDate:{Date}", async (DataContext context, DateTime Date) =>
{
    var _calendarDate = await context.calendarDates.FirstOrDefaultAsync(c => c.date.Equals(Date));

    if (_calendarDate == null)
        return Results.NotFound("Calendar not found");

    var _calendarDateDTO = new CalendarDateDTO()
    {
        Id = _calendarDate.Id,
        Date = _calendarDate.date,
        ServiceId = _calendarDate.serviceId
    };

    return Results.Ok(_calendarDateDTO);

});

app.MapPut("/CalendarDate/{Id}", async (DataContext context, CalendarDatePutDTO calendarDateDTO, int Id) =>
{
    var _checkExist = await context.calendarDates.FirstOrDefaultAsync(c => c.Id == Id);

    if (_checkExist == null)
        return Results.BadRequest("Calendar date does not exists");


    _checkExist.date = calendarDateDTO.Date;
    _checkExist.serviceId = calendarDateDTO.ServiceId;

    context.calendarDates.Update(_checkExist);
    await context.SaveChangesAsync();

    var _retVal = new CalendarDateDTO()
    {
        Id = _checkExist.Id,
        ServiceId = _checkExist.serviceId,
        Date = _checkExist.date

    };

    return Results.Ok();

});

app.MapDelete("/CalendarDate/{Id}", async (DataContext context, int Id) =>
{ 
    var calendarDateItem = await context.calendarDates.FindAsync(Id);
    if (calendarDateItem == null)
        return Results.NotFound("CalendarDate not found");

    context.calendarDates.Remove(calendarDateItem);
    await context.SaveChangesAsync();
    return Results.Ok("Successfully deleted");


});

//ROUTE 
//async Task<List<WebAPI.Models.Route>> GetRoutes(DataContext context) => await context.routes.ToListAsync();

app.MapPost("/Route", async(DataContext context, RoutePostDTO item) =>
{
    var _checkExist = await context.routes.FirstOrDefaultAsync(r => r.routeName.Contains(item.Name));

    if (_checkExist != null)
        return Results.BadRequest("Route already exists");

    var _newRoute = new WebAPI.Models.Route()
    {
        routeColor = item.Color,
        routeName = item.Name

    };

    context.routes.Add(_newRoute);
    await context.SaveChangesAsync();

    var _retValue = new RouteDTO()
    {
        Id = _newRoute.Id,
        Name = _newRoute.routeName,
        Color = _newRoute.routeColor
    };

    return Results.Created("", _retValue);

});

app.MapGet("/Route/AllRoutes", async (DataContext context) =>
{
    var _routes = await context.routes.ToListAsync();

    var _routesDTO = _routes.Select(row => new RouteGetBasicDTO()
    {
        Id = row.Id,
        Name = row.routeName

    }).ToList();

    return Results.Ok(_routesDTO);

});

app.MapGet("/Route/ById:{Id}", async (DataContext context, int Id) =>
{
    var _route = await context.routes.FirstOrDefaultAsync(r => r.Id == Id);

    if (_route == null)
        return Results.NotFound("Route not found");

    var _routeDTO = new RouteDTO()
    {
        Id = _route.Id,
        Name = _route.routeName,
        Color = _route.routeColor
    };

    return Results.Ok(_routeDTO); 

});

app.MapGet("/Route/ByName:{Name}", async (DataContext context, String Name) =>
{
    var _route = await context.routes.FirstOrDefaultAsync(r => r.routeName.Equals(Name));

    if (_route == null)
        return Results.NotFound("Route not found");

    var _routeDTO = new RouteDTO()
    {
        Id = _route.Id,
        Name = _route.routeName,
        Color = _route.routeColor
    };

    return Results.Ok(_routeDTO);

});

app.MapPut("/Route/{Id}", async (DataContext context, RoutePutDTO routeDTO, int Id) =>
{
    var _checkExist = await context.routes.FirstOrDefaultAsync(c => c.Id == Id);

    if (_checkExist == null)
        return Results.BadRequest("Calendar does not exists");

    _checkExist.routeColor = routeDTO.Color;
    _checkExist.routeName = routeDTO.Name;

    context.routes.Update(_checkExist);
    await context.SaveChangesAsync();

    var _retVal = new RouteDTO()
    {
        Id = _checkExist.Id,
        Color = _checkExist.routeColor,
        Name = _checkExist.routeName

    };

    return Results.Ok();
});

app.MapDelete("/Route/{Id}", async (DataContext context, int Id) =>
{
   var routeItem = await context.routes.FindAsync(Id);

    if (routeItem == null)
       return Results.NotFound("Route not found ");

    context.routes.Remove(routeItem);
    await context.SaveChangesAsync();
    return Results.Ok("Successfully deleted");

});


//TRIP
//async Task<List<Trip>> GetTrips(DataContext context) => await context.trips.ToListAsync();

app.MapPost("/Trip", async (DataContext context, TripPostDTO item) =>
{
    var _checkExist = await context.trips.FirstOrDefaultAsync(t => t.serviceId.Equals(item.ServiceId) && t.routeId.Equals(item.RouteId));

    if (_checkExist != null)
        return Results.BadRequest("Trip already exists");

    var _newTrip = new Trip()
    {
        serviceId = item.ServiceId,
        routeId = item.RouteId
    };

    context.trips.Add(_newTrip);
    await context.SaveChangesAsync();

    var _retValue = new TripDTO()
    {
        Id = _newTrip.Id,
        ServiceId = _newTrip.serviceId,
        RouteId = _newTrip.routeId
    };

    return Results.Created("",_retValue);
}); 

app.MapGet("/Trip/AllTrips", async(DataContext context)=>
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

    var _tripDTO = new TripDTO()
    {
        Id = _trip.Id,
        RouteId = _trip.routeId,
        ServiceId = _trip.serviceId
    };

    return Results.Ok(_tripDTO);

});

app.MapPut("/Trip/{Id}", async (DataContext context, TripPostDTO tripDTO, int Id) =>
{
    var _checkExist = await context.trips.FirstOrDefaultAsync(c => c.Id == Id);

    if (_checkExist == null)
        return Results.BadRequest("Trip not exists");

    _checkExist.routeId = tripDTO.RouteId;
    _checkExist.serviceId = tripDTO.ServiceId;

    context.trips.Update(_checkExist);
    await context.SaveChangesAsync();

    var _retVal = new TripDTO()
    {
        Id = _checkExist.Id,
        RouteId = _checkExist.routeId,
        ServiceId = _checkExist.serviceId
    };

    return Results.Ok();

});

app.MapDelete("/Trip/{Id}", async (DataContext context, int Id) =>
{
    var tripItem = await context.trips.FindAsync(Id);

    if (tripItem == null)
        return Results.NotFound("Trip not found");

    context.trips.Remove(tripItem);
    await context.SaveChangesAsync();
    return Results.Ok("Successfully deleted");
});

//STOP

//async Task<List<Stop>> GetStops(DataContext context) => await context.stops.ToListAsync();

app.MapPost("/Stop", async (DataContext context, StopPostDTO item) =>
{
    var _checkExist = await context.stops.FirstOrDefaultAsync(s => s.stopName.Contains(item.Name));

    if (_checkExist != null)
        return Results.BadRequest("Stop already exists");

    var _newStop = new Stop()
    {
        stopName = item.Name,
        stopLat = item.Lat,
        stopLon = item.Lon,
        routeBelong = item.RouteBelong
    };

    context.stops.Add(_newStop);
    await context.SaveChangesAsync();

    var _retVal = new StopDTO()
    {
        Id = _newStop.Id,
        Name = _newStop.stopName,
        Lat = _newStop.stopLat,
        Lon = _newStop.stopLon,
        RouteBelong = _newStop.routeBelong
    };

    return Results.Created("", _retVal); 
    
});

app.MapGet("/Stop/AllStops", async (DataContext context) =>
{ 
    var _stops = await context.stops.ToListAsync();

    var _stopsDTO = _stops.Select(row => new StopGetBasicDTO()
    {
        Id = row.Id,
        Name = row.stopName
    }).ToList();

    return Results.Ok(_stopsDTO); 

});

app.MapGet("/Stop/ById:{Id}", async (DataContext context, int Id) =>
{
    var _stop = await context.stops.FirstOrDefaultAsync(s => s.Id == Id);

    if (_stop == null)
        return Results.NotFound("Stop not found");

    var _stopDTO = new StopDTO()
    {
        Id = _stop.Id,
        Name = _stop.stopName,
        Lat = _stop.stopLat,
        Lon = _stop.stopLon,
        RouteBelong = _stop.routeBelong
    };

    return Results.Ok(_stopDTO); 

});

app.MapGet("/Stop/ByName:{Name}", async (DataContext context, string Name) =>
{
    var _stop = await context.stops.FirstOrDefaultAsync(s => s.stopName.Contains(Name));

    if (_stop == null)
        return Results.NotFound("Stop not found");

    var _stopDTO = new StopDTO()
    {
        Id = _stop.Id,
        Name = _stop.stopName,
        Lat = _stop.stopLat,
        Lon = _stop.stopLon,
        RouteBelong = _stop.routeBelong
    };

    return Results.Ok(_stopDTO);

});

app.MapGet("/Stop/ByRouteBelong:{routeBelong}", async (DataContext context, string routeBelong) =>
{
    var _stop = await context.stops.FirstOrDefaultAsync(s => s.routeBelong.Contains(routeBelong));

    if (_stop == null)
        return Results.NotFound("Stop not found");

    var _stopDTO = new StopDTO()
    {
        Id = _stop.Id,
        Name = _stop.stopName,
        Lat = _stop.stopLat,
        Lon = _stop.stopLon,
        RouteBelong = _stop.routeBelong
    };

    return Results.Ok(_stopDTO);

});

app.MapPut("/Stop/{Id}", async (DataContext context, StopPutDTO stopDTO, int Id) =>
{
    var _checkExist = await context.stops.FirstOrDefaultAsync(c => c.Id == Id);

    if (_checkExist == null)
        return Results.BadRequest("Stop do not exists");

    _checkExist.stopName = stopDTO.Name;
    _checkExist.stopLat = stopDTO.Lat;
    _checkExist.stopLon = stopDTO.Lon;
    _checkExist.routeBelong = stopDTO.RouteBelong;

    context.stops.Update(_checkExist);
    await context.SaveChangesAsync();

    var _retVal = new StopDTO()
    {
        Id = _checkExist.Id,
        Name = _checkExist.stopName,
        Lat = _checkExist.stopLat,
        Lon = _checkExist.stopLon,
        RouteBelong = _checkExist.routeBelong
    };

    return Results.Ok();

});

app.MapDelete("/Stop/{Id}", async (DataContext context, int Id) =>
{
    var stopItem = await context.stops.FindAsync(Id);
    if (stopItem == null)
        return Results.NotFound("Stop not found");

    context.stops.Remove(stopItem);
    await context.SaveChangesAsync();
    return Results.Ok("Successfully deleted");


});

//STOP TIME
//async Task<List<StopTime>> GetStopTimes(DataContext context) => await context.stopTimes.ToListAsync();

app.MapPost("/StopTime", async (DataContext context, StopTimePostDTO item) =>
{
    var _checkExist = await context.stopTimes.FirstOrDefaultAsync(s => s.stopId.Equals(item.StopId) && s.tripId.Equals(item.TripId));

    if (_checkExist != null)
        return Results.BadRequest("Stop time already exists");

    var _newStopTime = new StopTime()
    {
        stopId = item.StopId,
        stopSequence = item.StopSequence,
        tripId = item.TripId
    };

    context.stopTimes.Add(_newStopTime);
    await context.SaveChangesAsync();

    var _retValue = new StopTimeDTO()
    {
        Id = _newStopTime.Id,
        StopId = _newStopTime.stopId,
        StopSequence = _newStopTime.stopSequence,
        TripId = _newStopTime.tripId
    };

    return Results.Created("", _retValue);
});

app.MapGet("/StopTime/AllStopTimes", async (DataContext context) =>
   {
       var _stopTimes = await context.stopTimes.ToListAsync();

       var _stopTimesDTO = _stopTimes.Select(row => new StopTimeGetBasicDTO()
       {
           Id = row.Id,
           StopSequence = row.stopSequence

       }).ToList();

       return Results.Ok(_stopTimesDTO); 
    
   });

app.MapGet("/StopTime/{Id}", async (DataContext context, int Id) =>
{ 
    var _stopTime = await context.stopTimes.FirstOrDefaultAsync(s => s.Id == Id);

    if (_stopTime == null)
        return Results.NotFound("Stop time not found");

    var _stopTimeDTO = new StopTimeDTO()
    {
        Id = _stopTime.Id,
        StopId = _stopTime.stopId,
        StopSequence = _stopTime.stopSequence,
        TripId = _stopTime.tripId
    };

    return Results.Ok(_stopTimeDTO);

});

app.MapPut("/StopTime/{Id}", async (DataContext context, int Id, StopTimePutDTO stopTimeDTO) =>
{
    var _checkExist = await context.stopTimes.FirstOrDefaultAsync(c => c.Id == Id);

    if (_checkExist == null)
        return Results.BadRequest("Stop time do not exists");

    _checkExist.tripId = stopTimeDTO.TripId;
    _checkExist.stopId = stopTimeDTO.StopId;
    _checkExist.stopSequence = stopTimeDTO.StopSequence;

    context.stopTimes.Update(_checkExist);
    await context.SaveChangesAsync();

    var _retVal = new StopTimeDTO()
    {
        Id = _checkExist.Id,
        TripId = _checkExist.tripId,
        StopId= _checkExist.stopId,
        StopSequence = _checkExist.stopSequence
    };

    return Results.Ok();
});

app.MapDelete("/StopTime/{Id}", async (DataContext context, int Id) =>  
{
    var StopTimeItem = await context.stopTimes.FindAsync(Id);

    if (StopTimeItem == null)
        return Results.NotFound("Stop time not found");

    context.stopTimes.Remove(StopTimeItem);
    await context.SaveChangesAsync();
    return Results.Ok("Successfully deleted");

});

//USER
//async Task<List<User>> GetUsers(DataContext context) => await context.users.ToListAsync();

app.MapPost("/User", async (DataContext context, UserPostDTO item) =>
{
    var _checkExist = await context.users.FirstOrDefaultAsync(s => s.username.Contains(item.username) || s.email.Contains(item.email));

    if (_checkExist != null)
        return Results.BadRequest("User already exists");

    var _newUser = new User()
    {
        name = item.name,
        lastname = item.lastname,
        address = item.address,
        email = item.email,
        username = item.username,
        password = item.password
    };

    context.users.Add(_newUser);
    await context.SaveChangesAsync();

    var _retValue = new UserDTO()
    {
        Id = _newUser.Id,
        Name = _newUser.name,
        Lastname = _newUser.lastname,
        Address = _newUser.address,
        Email = _newUser.email,
        Username = _newUser.username,
        Password = _newUser.password
    };

    return Results.Created("", _retValue);
});

app.MapGet("/User/AllUsers", async (DataContext context) =>
{
    var _users = await context.users.ToListAsync();

    var _usersDTO = _users.Select(row => new UserGetBasicDTO()
    {
        Id = row.Id,
        Name = row.username,
        Email = row.email

    }).ToList();

    return Results.Ok(_usersDTO);

});

app.MapGet("/User/ById:{Id}", async (DataContext context, int Id) =>
{
    var _user = await context.users.FirstOrDefaultAsync(u => u.Id == Id);

    if (_user == null)
        return Results.NotFound("User not found");

    var _userDTO = new UserDTO()
    {
        Id = _user.Id,
        Name = _user.name,
        Lastname = _user.lastname,
        Address = _user.address,
        Email = _user.email,
        Username = _user.username,
        Password = _user.password
    };

    return Results.Ok(_userDTO);

});

app.MapGet("/User/By Username:{Username}", async (DataContext context, string Username) =>
{
    var _user = await context.users.FirstOrDefaultAsync(u => u.username == Username);

    if (_user == null)
        return Results.NotFound("User not found");

    var _userDTO = new UserDTO()
    {
        Id = _user.Id,
        Name = _user.name,
        Lastname = _user.lastname,
        Address = _user.address,
        Email = _user.email,
        Username = _user.username,
        Password = _user.password
    };

    return Results.Ok(_userDTO);

});

app.MapPut("/User/{Id}", async (DataContext context, UserPutDTO userDTO, int Id) =>
{
    var _checkExist = await context.users.FirstOrDefaultAsync(u => u.Id == Id);

    if (_checkExist == null)
        return Results.BadRequest("User do not exists");

    _checkExist.name = userDTO.name;
    _checkExist.lastname = userDTO.lastname;
    _checkExist.address = userDTO.address;
    _checkExist.email = userDTO.email;
    _checkExist.username = userDTO.username;
    _checkExist.password = userDTO.password;

    context.users.Update(_checkExist);
    await context.SaveChangesAsync();

    var _retVal = new UserDTO()
    {
        Id = _checkExist.Id,
        Name = _checkExist.name,
        Lastname = _checkExist.lastname,
        Address = _checkExist.address,
        Email = _checkExist.email,
        Username = _checkExist.username,
        Password = _checkExist.password

    };

    return Results.Ok();

});

app.MapDelete("/User/{Id}", async (DataContext context, int Id) =>
{
    var userItem = await context.users.FindAsync(Id);
    if (userItem == null)
        return Results.NotFound("User not found");

    context.users.Remove(userItem);
    await context.SaveChangesAsync();
    return Results.Ok("Successfully deleted");
});


app.Run();
