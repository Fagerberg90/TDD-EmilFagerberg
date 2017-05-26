using EmployeeRegistrey;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistry.Tests
{
    public class RegistryTests
    {
        private Registry sut;
        private Dictionary<string, Employee> employees;
        private Employee employee1;
        private Employee employee2;

        [SetUp]
        public void Setup()
        {
            employees = new Dictionary<string, Employee>();
            var employee1 = new Employee("Emil", "Fagerberg", "900215-0309");
            var employee2 = new Employee("Nisse", "Larsson", "890214-0218");


            sut = new Registry();
        }


        [Test]
        public void StartWithZeroEmplyees()
        {

            var result = sut.AllEmployees();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);

        }

        [Test]
        public void CanSeedEmployeesOnConstruct()
        {

            employees.Add(employee1.Ssn, employee1);
            employees.Add(employee2.Ssn, employee2);

            sut = new Registry(employees);

            var result = sut.AllEmployees();

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void CanHireAnEmployee()
        {

            var employee = new Employee("kalle","andersson","890215-4524");
            sut.Hire(employee);

            var result = sut.AllEmployees();

            Assert.AreEqual(1, result.Count);

            Assert.AreEqual("Kalle", result[0].FirstName);

        }
        [Test]
        public void HireWithInvalidSsn_ThrowException()
        {

            var employee = new Employee("kalle", "andersson", "890215-4524");


            sut.Hire(employee);
          

            Assert.Throws<InvalidSsnException>(() =>
            {
                sut.Hire(employee);


            });
        }
    }
}
