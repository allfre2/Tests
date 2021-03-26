using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Context
{
    public class SeedData
    {
        public static readonly Random random = new Random();

        public static IEnumerable<PermissionType> GetPermissionTypes()
        {
            return new List<PermissionType> 
            {
                new PermissionType 
                { 
                    Id = 1,
                    Description = "Enfermedad, Licencia Médica"
                },
                new PermissionType
                {
                    Id = 2,
                    Description = "Diligencias"
                },
                new PermissionType
                {
                    Id = 3,
                    Description = "Maternidad"
                },
                new PermissionType
                {
                    Id = 4,
                    Description = "Licencia de Estudios"
                },
                new PermissionType
                {
                    Id = 5,
                    Description = "Otros"
                }
            };
        }

        // Random
        public static IEnumerable<Permission> GetPermissions(int min = 5, int max = 10)
        {
            var names = new List<string> 
            { 
                "Alan", "Alfredo", "David", "Sunil", "Leonardo", "Alcy", "Juan Carlos", "Ennio",
                "Alberto", "Guillermo", "Charlie", "Quentin", "Butch", "Elvis", "Larry", "Mikhail"
            };

            var lastNames = new List<string> 
            { 
                "Turing", "Richter", "Part", "Sibelius", "Morricone", "Skrillex", "Gosling", "Von Doom", "Luzón",
                "Perreira", "Vazquez", "Asuncion", "Velazquez", "Smith", "Norris", "Rotzank", "Kitchen", "Vivaldi"
            };

            var permissionTypes = GetPermissionTypes().ToList();

            return Enumerable.Range(1, random.Next(min, max) + 1)
                .Select(id => new Permission
                {
                    Id = id,
                    EmployeeName = names[random.Next(0, names.Count)],
                    EmployeeLastName = lastNames[random.Next(0, lastNames.Count)],
                    PermissionTypeId = permissionTypes[random.Next(0, permissionTypes.Count)].Id,
                    PermissionDate = DateTime.Now.AddDays(- (random.Next(0, 8)))
                });
        }
    }
}
