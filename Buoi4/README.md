Giải thích:
Luồng hoạt động code: 
- Khi đang ở bài 4 sẽ có mũi tên trỏ sang bài 5 bằng thẻ <a> với asp-controller="Book" nghĩa là nó sẽ trỏ tới folder Controller và trỏ tới BookController.cs. asp-action="Index" là trỏ tới hành động mang tên Index trong file BookController.cs
- Hành động Index trong BookController return View(books) là trả về hành động trong folder Views\Book với dữ liệu List biến books khai báo trước đó
- Module tự nhận giá trị của books truyền vào trước đó ở file View\Book và chạy vào tên .cshtml cùng tên tới action return View ở trên tương ứng (Index.cshtml)
- Sau đó sẽ hiển thị các danh sách sách qua foreach biến Module.
- Đó là chức năng hiển thị danh sách sách, khi muốn thực hiện thao tác thêm sách thì click vào mục thêm sách trên đầu thanh taskbar thì nó sẽ trỏ tới asp-controller="Book" và asp-action="Create" tương ứng.
- Khi người dùng truy cập theo Book\Create thì sẽ vào get của action Create và return View
- Khi vào View Create sẽ chạy hiện giao diện code html
- Trong giao diện có chức năng nhập tên sách và giá, sau khi submit sẽ tạo Name= Name, Price = Price sau đó gửi tới model book tạo book mới và check điều kiện, nếu hợp lý thì gửi tới post trong action của create và thêm vào list book ban đầu.
- Khi truy cập theo url Book/Detail/1 thì sẽ truy cập vào controller của book, vào action Detail có nhận đầu vào là int, nó sẽ tìm kiềm theo id, nếu có thì trả ra View biến book có id tương ứng, không có trả về not found.
