using ECommerceDDD.Domain.Abstractions;
using ECommerceDDD.Domain.Shared;
using System.Net;

namespace ECommerceDDD.Domain.Users
{
	public sealed class User : Entity
	{
		private User(Guid id) : base(id)
		{

		}
		private User(Guid id,
					Name name,
					Email email,
					Password password,
					Address address) : base(id)
		{
			Name = name;
			Email = email;
			Password = password;
			Address = address;
		}

		public Name Name { get; private set; }
		public Email Email { get; private set; }
		public Password Password { get; private set; }
		public Address Address { get; private set; }

		public static User CreateUser(string name, string email, string password, string country, string city, string street, string fullAddress, string postalCode)
		{
			//Factory mantığı örneği
			//Bu kısımda ek kontroller yapılabilir

			var user = new User
			(
				id: new Guid(),
				name: new Name(name),
				email: new Email(email),
				password: new Password(password),
				address: new Address(country, city, street, fullAddress, postalCode)
			);

			return user;
		}

		public void ChangeName(string name)
		{
			Name = new Name(name);
		}

		public void ChangeAddress(string country, string city, string street, string fullAddress, string postalCode)
		{
			Address = new Address(country, city, street, fullAddress, postalCode);
		}

		public void ChangePassword(string password)
		{
			Password = new Password(password);
		}

		public void ChangeEmail(string email)
		{
			Email = new Email(email);
		}
	}
}
