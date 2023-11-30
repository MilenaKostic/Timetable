using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using Shared.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shared.DTO.Route;
using Shared.DTO.User;
using System;
using Microsoft.Identity.Client;
using System.Reflection.Metadata.Ecma335;

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
    var _checkExist = await context.calendars.FirstOrDefaultAsync(c => c.StartDate.Equals(item.StartDate) && c.EndDate.Equals(item.EndDate));

    if (_checkExist != null)
        return Results.BadRequest("Calendar already exists");

    var _newCalendar = new Calendar()
    {
        Monday = item.Monday,
        Tuesday = item.Tuesday,
        Wednesday = item.Wednesday,
        Thursday = item.Thursday,
        Friday = item.Friday,
        Saturday = item.Saturday,
        Sunday = item.Sunday,
        StartDate = item.StartDate,
        EndDate = item.EndDate
    };

    context.calendars.Add(_newCalendar);
    await context.SaveChangesAsync();

    var _retVal = new CalendarDTO()
    {
        Id = _newCalendar.Id,
        Monday = _newCalendar.Monday,
        Tuesday = _newCalendar.Tuesday,
        Wednesday = _newCalendar.Wednesday,
        Thursday = _newCalendar.Thursday,
        Friday = _newCalendar.Friday,
        Saturday = _newCalendar.Saturday,
        Sunday = _newCalendar.Sunday,
        StartDate = _newCalendar.StartDate,
        EndDate = _newCalendar.EndDate

    };

    return Results.Created("", _retVal); 


});

app.MapGet("/Calendar/AllCalendars", async (DataContext context) =>
{
    var _calendars = await context.calendars.ToListAsync();

    var _calendarsDTO = _calendars.Select(row => new CalendarGetBasicDTO()
    {
        Id = row.Id,
        Monday = row.Monday,
        Tuesday = row.Tuesday,
        Wednesday = row.Wednesday,
        Thursday = row.Thursday,
        Friday = row.Friday,
        Saturday = row.Saturday,
        Sunday = row.Sunday
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
        Monday = _calendar.Monday,
        Tuesday = _calendar.Thursday,
        Wednesday = _calendar.Wednesday,
        Thursday = _calendar.Thursday,
        Friday = _calendar.Friday,
        Saturday = _calendar.Saturday,
        Sunday = _calendar.Sunday,
        StartDate = _calendar.StartDate,
        EndDate = _calendar.EndDate
    };

    return Results.Ok(_calendarDTO); 
    

});

app.MapPut("/Calendar/{Id}", async (DataContext context, CalendarPutDTO calendarDTO, int Id) =>
{
    var _checkExist = await context.calendars.FirstOrDefaultAsync(c => c.Id == Id);

    if (_checkExist == null)
        return Results.BadRequest("Calendar does not exists");


    _checkExist.Monday = calendarDTO.Monday;
    _checkExist.Tuesday = calendarDTO.Tuesday;
    _checkExist.Wednesday = calendarDTO.Wednesday;
    _checkExist.Thursday = calendarDTO.Thursday;
    _checkExist.Friday = calendarDTO.Friday;
    _checkExist.Saturday = calendarDTO.Saturday;
    _checkExist.Sunday = calendarDTO.Sunday;
    _checkExist.StartDate = calendarDTO.StartDate;
    _checkExist.EndDate = calendarDTO.EndDate;
    

    context.calendars.Update(_checkExist);
    await context.SaveChangesAsync();

    var _retVal = new CalendarDTO()
    {
        Id = _checkExist.Id,
        Monday = _checkExist.Monday,
        Tuesday = _checkExist.Tuesday,
        Wednesday = _checkExist.Wednesday,
        Thursday = _checkExist.Thursday,
        Friday = _checkExist.Friday,
        Saturday = _checkExist.Saturday,
        Sunday = _checkExist.Sunday,
        StartDate = _checkExist.StartDate,
        EndDate = _checkExist.EndDate

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
    var _checkExist = await context.calendarDates.FirstOrDefaultAsync(c => c.ServiceId.Equals(item.ServiceId) && c.Date.Equals(item.Date));

    if (_checkExist != null)
        return Results.BadRequest("Calendar date already exists");

    var _newCalendarDate = new CalendarDate()
    {
        ServiceId = item.ServiceId,
        Date = item.Date
    };

    context.calendarDates.Add(_newCalendarDate);
    await context.SaveChangesAsync();

    var _retValue = new CalendarDateDTO()
    {
        Id = _newCalendarDate.Id,
        ServiceId = _newCalendarDate.ServiceId,
        Date = _newCalendarDate.Date
    };

    return Results.Created("", _retValue);
});

app.MapGet("/CalendarDate/AllCalendarDates", async (DataContext context) =>
{
    var _calendarDates = await context.calendarDates.ToListAsync();

    var _calendarDatesDTO = _calendarDates.Select(row => new CalendarDateGetBasicDTO()
    {
        Id = row.Id,
        Date = row.Date
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
        Date = _calendarDate.Date,
        ServiceId = _calendarDate.ServiceId
    };

    return Results.Ok(_calendarDateDTO); 

});

app.MapGet("/CalendarDate/ByDate:{Date}", async (DataContext context, DateTime Date) =>
{
    var _calendarDate = await context.calendarDates.FirstOrDefaultAsync(c => c.Date.Equals(Date));

    if (_calendarDate == null)
        return Results.NotFound("Calendar not found");

    var _calendarDateDTO = new CalendarDateDTO()
    {
        Id = _calendarDate.Id,
        Date = _calendarDate.Date,
        ServiceId = _calendarDate.ServiceId
    };

    return Results.Ok(_calendarDateDTO);

});

app.MapPut("/CalendarDate/{Id}", async (DataContext context, CalendarDatePutDTO calendarDateDTO, int Id) =>
{
    var _checkExist = await context.calendarDates.FirstOrDefaultAsync(c => c.Id == Id);

    if (_checkExist == null)
        return Results.BadRequest("Calendar date does not exists");


    _checkExist.Date = calendarDateDTO.Date;
    _checkExist.ServiceId = calendarDateDTO.ServiceId;

    context.calendarDates.Update(_checkExist);
    await context.SaveChangesAsync();

    var _retVal = new CalendarDateDTO()
    {
        Id = _checkExist.Id,
        ServiceId = _checkExist.ServiceId,
        Date = _checkExist.Date

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
    var _checkExist = await context.routes.FirstOrDefaultAsync(r => r.RouteName.Contains(item.Name));

    if (_checkExist != null)
        return Results.BadRequest("Route already exists");

    var _newRoute = new WebAPI.Models.Route()
    {
        RouteColor = item.Color,
        RouteName = item.Name

    };

    context.routes.Add(_newRoute);
    await context.SaveChangesAsync();

    var _retValue = new RouteDTO()
    {
        Id = _newRoute.Id,
        Name = _newRoute.RouteName,
        Color = _newRoute.RouteColor
    };

    return Results.Created("", _retValue);

});

app.MapGet("/Route/AllRoutes", async (DataContext context) =>
{
    var _routes = await context.routes.ToListAsync();

    var _routesDTO = _routes.Select(row => new RouteGetBasicDTO()
    {
        Id = row.Id,
        Name = row.RouteName

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
        Name = _route.RouteName,
        Color = _route.RouteColor
    };

    return Results.Ok(_routeDTO); 

});

app.MapGet("/Route/ByName:{Name}", async (DataContext context, String Name) =>
{
    var _route = await context.routes.FirstOrDefaultAsync(r => r.RouteName.Equals(Name));

    if (_route == null)
        return Results.NotFound("Route not found");

    var _routeDTO = new RouteDTO()
    {
        Id = _route.Id,
        Name = _route.RouteName,
        Color = _route.RouteColor
    };

    return Results.Ok(_routeDTO);

});

app.MapPut("/Route/{Id}", async (DataContext context, RoutePutDTO routeDTO, int Id) =>
{
    var _checkExist = await context.routes.FirstOrDefaultAsync(c => c.Id == Id);

    if (_checkExist == null)
        return Results.BadRequest("Calendar does not exists");

    _checkExist.RouteColor = routeDTO.Color;
    _checkExist.RouteName = routeDTO.Name;

    context.routes.Update(_checkExist);
    await context.SaveChangesAsync();

    var _retVal = new RouteDTO()
    {
        Id = _checkExist.Id,
        Color = _checkExist.RouteColor,
        Name = _checkExist.RouteName

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
    var _checkExist = await context.trips.FirstOrDefaultAsync(t => t.ServiceId.Equals(item.ServiceId) && t.RouteId.Equals(item.RouteId));

    if (_checkExist != null)
        return Results.BadRequest("Trip already exists");

    var _newTrip = new Trip()
    {
        ServiceId = item.ServiceId,
        RouteId = item.RouteId
    };

    context.trips.Add(_newTrip);
    await context.SaveChangesAsync();

    var _retValue = new TripDTO()
    {
        Id = _newTrip.Id,
        ServiceId = _newTrip.ServiceId,
        RouteId = _newTrip.RouteId
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
        RouteId = _trip.RouteId,
        ServiceId = _trip.ServiceId
    };

    return Results.Ok(_tripDTO);

});

app.MapPut("/Trip/{Id}", async (DataContext context, TripPostDTO tripDTO, int Id) =>
{
    var _checkExist = await context.trips.FirstOrDefaultAsync(c => c.Id == Id);

    if (_checkExist == null)
        return Results.BadRequest("Trip not exists");

    _checkExist.RouteId = tripDTO.RouteId;
    _checkExist.ServiceId = tripDTO.ServiceId;

    context.trips.Update(_checkExist);
    await context.SaveChangesAsync();

    var _retVal = new TripDTO()
    {
        Id = _checkExist.Id,
        RouteId = _checkExist.RouteId,
        ServiceId = _checkExist.ServiceId
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
    var _checkExist = await context.stops.FirstOrDefaultAsync(s => s.StopName.Contains(item.Name));

    if (_checkExist != null)
        return Results.BadRequest("Stop already exists");

    var _newStop = new Stop()
    {
        StopName = item.Name,
        StopLat = item.Lat,
        StopLon = item.Lon
    };

    context.stops.Add(_newStop);
    await context.SaveChangesAsync();

    var _retVal = new StopDTO()
    {
        Id = _newStop.Id,
        Name = _newStop.StopName,
        Lat = _newStop.StopLat,
        Lon = _newStop.StopLon
    };

    return Results.Created("", _retVal); 
    
});

app.MapGet("/Stop/AllStops", async (DataContext context) =>
{ 
    var _stops = await context.stops.ToListAsync();

    var _stopsDTO = _stops.Select(row => new StopGetBasicDTO()
    {
        Id = row.Id,
        Name = row.StopName
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
        Name = _stop.StopName,
        Lat = _stop.StopLat,
        Lon = _stop.StopLon
    };

    return Results.Ok(_stopDTO); 

});

app.MapGet("/Stop/ByName:{Name}", async (DataContext context, string Name) =>
{
    var _stop = await context.stops.FirstOrDefaultAsync(s => s.StopName.Contains(Name));

    if (_stop == null)
        return Results.NotFound("Stop not found");

    var _stopDTO = new StopDTO()
    {
        Id = _stop.Id,
        Name = _stop.StopName,
        Lat = _stop.StopLat,
        Lon = _stop.StopLon
    };

    return Results.Ok(_stopDTO);

});

app.MapPut("/Stop/{Id}", async (DataContext context, StopPutDTO stopDTO, int Id) =>
{
    var _checkExist = await context.stops.FirstOrDefaultAsync(c => c.Id == Id);

    if (_checkExist == null)
        return Results.BadRequest("Stop do not exists");

    _checkExist.StopName = stopDTO.Name;
    _checkExist.StopLat = stopDTO.Lat;
    _checkExist.StopLon = stopDTO.Lon;

    context.stops.Update(_checkExist);
    await context.SaveChangesAsync();

    var _retVal = new StopDTO()
    {
        Id = _checkExist.Id,
        Name = _checkExist.StopName,
        Lat = _checkExist.StopLat,
        Lon = _checkExist.StopLon
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
    var _checkExist = await context.stopTimes.FirstOrDefaultAsync(s => s.StopId.Equals(item.StopId) && s.TripId.Equals(item.TripId));

    if (_checkExist != null)
        return Results.BadRequest("Stop time already exists");

    var _newStopTime = new StopTime()
    {
        StopId = item.StopId,
        StopSequence = item.StopSequence,
        TripId = item.TripId
    };

    context.stopTimes.Add(_newStopTime);
    await context.SaveChangesAsync();

    var _retValue = new StopTimeDTO()
    {
        Id = _newStopTime.Id,
        StopId = _newStopTime.StopId,
        StopSequence = _newStopTime.StopSequence,
        TripId = _newStopTime.TripId
    };

    return Results.Created("", _retValue);
});

app.MapGet("/StopTime/AllStopTimes", async (DataContext context) =>
   {
       var _stopTimes = await context.stopTimes.ToListAsync();

       var _stopTimesDTO = _stopTimes.Select(row => new StopTimeGetBasicDTO()
       {
           Id = row.Id,
           StopSequence = row.StopSequence

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
        StopId = _stopTime.StopId,
        StopSequence = _stopTime.StopSequence,
        TripId = _stopTime.TripId
    };

    return Results.Ok(_stopTimeDTO);

});

app.MapPut("/StopTime/{Id}", async (DataContext context, int Id, StopTimePutDTO stopTimeDTO) =>
{
    var _checkExist = await context.stopTimes.FirstOrDefaultAsync(c => c.Id == Id);

    if (_checkExist == null)
        return Results.BadRequest("Stop time do not exists");

    _checkExist.TripId = stopTimeDTO.TripId;
    _checkExist.StopId = stopTimeDTO.StopId;
    _checkExist.StopSequence = stopTimeDTO.StopSequence;

    context.stopTimes.Update(_checkExist);
    await context.SaveChangesAsync();

    var _retVal = new StopTimeDTO()
    {
        Id = _checkExist.Id,
        TripId = _checkExist.TripId,
        StopId= _checkExist.StopId,
        StopSequence = _checkExist.StopSequence
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
    var _checkExist = await context.users.FirstOrDefaultAsync(s => s.Username.Contains(item.Username) || s.Email.Contains(item.Email));

    if (_checkExist != null)
        return Results.BadRequest("User already exists");

    var _newUser = new User()
    {
        Name = item.Name,
        Lastname = item.Lastname,
        Address = item.Address,
        Email = item.Email,
        Username = item.Username,
        Password = item.Password
    };

    context.users.Add(_newUser);
    await context.SaveChangesAsync();

    var _retValue = new UserDTO()
    {
        Id = _newUser.Id,
        Name = _newUser.Name,
        Lastname = _newUser.Lastname,
        Address = _newUser.Address,
        Email = _newUser.Email,
        Username = _newUser.Username,
        Password = _newUser.Password
    };

    return Results.Created("", _retValue);
});

app.MapGet("/User/AllUsers", async (DataContext context) =>
{
    var _users = await context.users.ToListAsync();

    var _usersDTO = _users.Select(row => new UserGetBasicDTO()
    {
        Id = row.Id,
        Name = row.Username,
        Email = row.Email

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
        Name = _user.Name,
        Lastname = _user.Lastname,
        Address = _user.Address,
        Email = _user.Email,
        Username = _user.Username,
        Password = _user.Password
    };

    return Results.Ok(_userDTO);

});

app.MapGet("/User/ByUsername:{Username}", async (DataContext context, string Username) =>
{
    var _user = await context.users.FirstOrDefaultAsync(u => u.Username == Username);

    if (_user == null)
        return Results.NotFound("User not found");

    var _userDTO = new UserDTO()
    {
        Id = _user.Id,
        Name = _user.Name,
        Lastname = _user.Lastname,
        Address = _user.Address,
        Email = _user.Email,
        Username = _user.Username,
        Password = _user.Password
    };

    return Results.Ok(_userDTO);

});

app.MapPut("/User/{Id}", async (DataContext context, UserPutDTO userDTO, int Id) =>
{
    var _checkExist = await context.users.FirstOrDefaultAsync(u => u.Id == Id);

    if (_checkExist == null)
        return Results.BadRequest("User do not exists");

    _checkExist.Name = userDTO.Name;
    _checkExist.Lastname = userDTO.Lastname;
    _checkExist.Address = userDTO.Address;
    _checkExist.Email = userDTO.Email;
    _checkExist.Username = userDTO.Username;
    _checkExist.Password = userDTO.Password;

    context.users.Update(_checkExist);
    await context.SaveChangesAsync();

    var _retVal = new UserDTO()
    {
        Id = _checkExist.Id,
        Name = _checkExist.Name,
        Lastname = _checkExist.Lastname,
        Address = _checkExist.Address,
        Email = _checkExist.Email,
        Username = _checkExist.Username,
        Password = _checkExist.Password

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


//ROUTESTOP
app.MapPost("/RouteStop", async (DataContext context, RouteStopPostDTO item) =>
{

    var _newRouteStop = new RouteStop();
    

    switch (item.PositionId)
    {
        case 1:
            {
                var stopsOnRoute = await context.routeStops.Where(r => r.RouteId == item.RouteId).ToListAsync();

                for(int i =0; i<stopsOnRoute?.Count; i++)
                {
                    stopsOnRoute[i].Rbr = stopsOnRoute[i].Rbr + 1;
                }

                _newRouteStop = new RouteStop()
                {
                    RouteId = item.RouteId,
                    Rbr = 1,
                    StopId = item.StopId,
                    TimeInterval = item.TimeInterval,
                    MetarDistance = item.MetarDistance
                };

                context.routeStops.Add(_newRouteStop);
                break;
            }
        case 2:
            {
                var _selectedRbr = item.SelectRbr ?? 0;

				if (_selectedRbr == 0)
                {
					_newRouteStop = new RouteStop()
					{
						RouteId = item.RouteId,
						Rbr = 1,
						StopId = item.StopId,
						TimeInterval = item.TimeInterval,
						MetarDistance = item.MetarDistance

					};

					context.routeStops.Add(_newRouteStop);

                    var stopsOnRoute = await context.routeStops.Where(r => r.RouteId == item.RouteId && r.Rbr >= _selectedRbr).ToListAsync();

					for (int i = 0; i < stopsOnRoute?.Count; i++)
					{
						stopsOnRoute[i].Rbr = stopsOnRoute[i].Rbr + 1;
					}

				}

                else
                {
                    _newRouteStop = new RouteStop()
                    {
                        RouteId = item.RouteId,
                        Rbr = _selectedRbr,
                        StopId = item.StopId,
                        TimeInterval = item.TimeInterval,
                        MetarDistance = item.MetarDistance

                    };

                    context.routeStops.Add(_newRouteStop);

                    var stopsOnRoute = await context.routeStops.Where( r => r.RouteId == item.RouteId && r.Rbr >= _selectedRbr).ToListAsync();

                    for(int i=0; i<stopsOnRoute?.Count; i++)
                    {
                        stopsOnRoute[i].Rbr = stopsOnRoute[i].Rbr +1;
                    }
                }
			                
                break;
            }
        case 3:
            {//posle selektovane 
				var _selectedRbr = item.SelectRbr ?? 0;
				var _routeStops = await context.routeStops.Where(r => r.RouteId == item.RouteId).ToListAsync();

				if (_routeStops.Count == 0)
				{
					_newRouteStop = new RouteStop()
					{
						RouteId = item.RouteId,
						Rbr = _selectedRbr,
						StopId = item.StopId,
						TimeInterval = item.TimeInterval,
						MetarDistance = item.MetarDistance

					};

					context.routeStops.Add(_newRouteStop);


				}

				else
				{
					_newRouteStop = new RouteStop()
					{
						RouteId = item.RouteId,
						Rbr = _selectedRbr + 1,
						StopId = item.StopId,
						TimeInterval = item.TimeInterval,
						MetarDistance = item.MetarDistance

					};

					context.routeStops.Add(_newRouteStop);

					var stopsOnRoute = await context.routeStops.Where(r => r.RouteId == item.RouteId && r.Rbr > _selectedRbr).ToListAsync();

					for (int i = 0; i < stopsOnRoute?.Count; i++)
					{
						stopsOnRoute[i].Rbr = stopsOnRoute[i].Rbr + 1;
					}
				}

				break;
			}
        case 4:
            {
                var lastRbr = await context.routeStops.Where(x => x.RouteId == item.RouteId).OrderBy(x => x.Rbr).LastOrDefaultAsync();
                var newRbr = (lastRbr?.Rbr ?? 0) + 1;

                _newRouteStop = new RouteStop()
                {
                    RouteId = item.RouteId,
                    Rbr = newRbr,
                    StopId = item.StopId,
                    TimeInterval = item.TimeInterval,
                    MetarDistance = item.MetarDistance
                };

                context.routeStops.Add(_newRouteStop);
                break;
            }
    }

   
    await context.SaveChangesAsync();

	var newRouteStop = await context.routeStops
		.Include(r => r.Route)
		.Include(s => s.Stop)
		.FirstOrDefaultAsync(x => x.Id == _newRouteStop.Id);

	var _retval = new RouteStopBasicDTO()
	{
		Id = newRouteStop.Id,
		Route = new RouteGetBasicDTO()
		{
			Id = newRouteStop.Route.Id,
			Name = newRouteStop.Route.RouteName,
		},
		Rbr = newRouteStop.Rbr,
		Stop = new StopGetBasicDTO()
		{
			Id = newRouteStop.Stop.Id,
			Name = newRouteStop.Stop.StopName
		}
	};


	return Results.Created("", _retval);



});

app.MapGet("/RouteStop/AllRouteStops", async (DataContext context) =>
{
    var _routeStops = await context.routeStops.ToListAsync();

    var _routeStopBasicDTO = _routeStops.Select(row => new RouteStopGetDTO()
    {
        Id = row.Id,
        Rbr = row.Rbr

    }).ToList();

    return Results.Ok(_routeStopBasicDTO);

});

app.MapGet("/RouteStop/ById:{RouteId}", async (DataContext context, int RouteId) =>
{
	var _routeStop = await context.routeStops.FirstOrDefaultAsync(u => u.RouteId == RouteId);

	if (_routeStop == null)
		return Results.NotFound("Route Stop not found");

    var routeStopEntity = await context
        .routeStops
        .Include(s => s.Stop)
        .Where(x => x.RouteId == RouteId)
        .OrderBy(r => r.Rbr)
        .ToListAsync();

    var routeStopDTO = routeStopEntity.Select(row => new RouteStopListDTO()
    {
        Id = row.Id,
        Rbr = row.Rbr,
        Stop = new StopDTO()
        {
            Id = row.Stop.Id,
            Name = row.Stop.StopName,
            Lat = row.Stop.StopLat,
            Lon = row.Stop.StopLon
        }

    }).ToList();

    return Results.Ok(routeStopDTO); 
});

app.MapDelete("/RouteStop/{Id}", async (DataContext context, int Id) =>
{
    var routestopItem = await context.routeStops.FindAsync(Id);
	if (routestopItem == null)
		return Results.NotFound("Route stop not found");

    var _selectedRbr = routestopItem.Rbr;

	var stopsOnRoute = await context.routeStops.Where(r => r.RouteId == routestopItem.RouteId && r.Rbr >= _selectedRbr).ToListAsync();


    for (int i = 0; i < stopsOnRoute?.Count; i++)
	{
		stopsOnRoute[i].Rbr = stopsOnRoute[i].Rbr -1 ;
	}

	context.routeStops.Remove(routestopItem);
	await context.SaveChangesAsync();
	return Results.Ok("Successfully deleted");
});


app.Run();
