public interface IDatabase {
    void Save(Customer customer);
    Customer Get(int id);
}

public class Database : IDatabase {
    public void Save(Customer customer) {
        // Code to save customer data to database
    }

    public Customer Get(int id) {
        // Code to get customer data from database
    }
}

public interface IUserRepository {
    void Save(User user);
    User Get(int id);
}

public class UserRepository : IUserRepository {
    private readonly IDatabase _database;

    public UserRepository(IDatabase database) {
        _database = database;
    }

    public void Save(User user) {
        _database.Save(user);
    }

    public User Get(int id) {
        return _database.Get(id);
    }
}

public interface ICustomerRepository {
    void Save(Customer customer);
    Customer Get(int id);
}

public class CustomerRepository : ICustomerRepository {
    private readonly IDatabase _database;

    public CustomerRepository(IDatabase database) {
        _database = database;
    }

    public void Save(Customer customer) {
        _database.Save(customer);
    }

    public Customer Get(int id) {
        return _database.Get(id);
    }
}

/* UserRepository và CustomerRepository đều nhận một đối tượng IDatabase thông qua constructor. 
Nhờ đó, các đối tượng này không còn phụ thuộc trực tiếp vào Database, mà phụ thuộc vào interface IDatabase.
==> Có thể thay đổi Database mà không phải sửa đổi code của UserRepository và CustomerRepository.
*/