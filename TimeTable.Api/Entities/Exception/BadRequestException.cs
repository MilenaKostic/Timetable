
using System;
namespace TimeTable.Api.Entities;
public abstract class BadRequestException : Exception
{
	protected BadRequestException(string message)
		: base(message)
	{
	}
}
