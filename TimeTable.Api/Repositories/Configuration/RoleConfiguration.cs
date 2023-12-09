﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TimeTable.Api.Repositories.Configuration;
public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
	public void Configure(EntityTypeBuilder<IdentityRole> builder)
	{

		builder.HasData(
			new IdentityRole { Name = "Manager", NormalizedName = "MANAGER" },
			new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
			new IdentityRole { Name = "User", NormalizedName = "USER" }
		);
	}
}