# BÀI 7 – Middleware cơ bản trong ASP.NET Core MVC

## 1. Middleware là gì?

Middleware là các component được sắp xếp thành một pipeline (chuỗi xử lý) trong ASP.NET Core. Mỗi middleware có thể:
- Nhận request từ phía trước
- Xử lý hoặc kiểm tra request
- Chuyển request cho middleware tiếp theo (hoặc không)
- Xử lý response trước khi trả về client

Mô hình pipeline:
```
Request → [Middleware1] → [Middleware2] → [Controller] → Response
           ←             ←                ←
```

## 2. Middleware khác Controller ở điểm nào?

| Middleware | Controller |
|---|---|
| Xử lý ở tầng pipeline, trước khi vào Controller | Xử lý logic nghiệp vụ của ứng dụng |
| Không biết đến Model / View | Có Model, View, và các service |
| Thường dùng cho cross-cutting concerns (log, auth, exception handling) | Xử lý business logic, routing cụ thể |
| Được đăng ký trong Program.cs | Được định nghĩa bằng class kế thừa Controller |

## 3. Giải thích các khái niệm

### `await _next(context);`

Dòng này gọi middleware tiếp theo trong pipeline. Nếu không có dòng này, request sẽ không được chuyển tiếp đến Controller (hoặc middleware tiếp theo). Nó hoạt động như một "cái cầu" nối middleware hiện tại với phần còn lại của pipeline.

### Vì sao `return;` trong middleware khiến request không vào Controller?

Khi middleware gọi `return;` trước khi chạy `await _next(context);`, pipeline bị ngắt — request không được chuyển tiếp. Middleware trả response trực tiếp (ví dụ: trả về lỗi 400) và kết thúc xử lý. Đây gọi là **short-circuiting** (mạch ngắn) trong pipeline.

## 4. Vị trí đặt middleware

### Nếu đặt middleware sau `app.MapControllerRoute(...)`

Khi middleware được đặt **sau** MapControllerRoute, request đã được xử lý bởi Controller và response đã được sinh ra. Middleware chỉ có thể can thiệp vào response (ví dụ: thêm header), không thể ngăn chặn hay kiểm soát request trước khi vào Controller. Điều này làm mất tác dụng của middleware muốn kiểm soát request đầu vào.

### Thêm middleware khác

Để thêm middleware khác, chỉ cần gọi tiếp các phương thức mở rộng hoặc `UseMiddleware<T>()` trong Program.cs, theo đúng thứ tự mong muốn:

```csharp
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<AnotherMiddleware>();
app.UseMiddleware<YetAnotherMiddleware>();
```

Thứ tự đăng ký = thứ tự thực thi trong pipeline.

## 5. Trả lời câu hỏi báo cáo

### Q1: Middleware trong ASP.NET Core dùng để làm gì?

Middleware dùng để xử lý request/response theo pipeline. Các tác vụ phổ biến: ghi log, xác thực, xử lý lỗi, nén response, chặn truy cập, CORS, v.v.

### Q2: Middleware khác Controller ở điểm nào?

Middleware hoạt động ở tầng hạ tầng (pipeline), xử lý các concern chung và không biết đến Model/View. Controller xử lý nghiệp vụ cụ thể cho từng route, có Model và View.

### Q3: Dòng `await _next(context);` có ý nghĩa gì?

Chuyển request đến middleware tiếp theo trong pipeline. Nếu không gọi, request sẽ không được xử lý tiếp.

### Q4: Vì sao khi middleware trả về `return;` thì request không đi tiếp vào Controller?

Vì middleware đã kết thúc pipeline (short-circuit), không gọi `_next()` nên request không bao giờ đến được Controller.

### Q5: Nếu đặt middleware sau `app.MapControllerRoute(...)` thì có thể xảy ra vấn đề gì?

Middleware chỉ xử lý được response (đã qua Controller), không thể kiểm soát request trước khi vào Controller. Mất khả năng ngăn chặn request sớm.

### Q6: Nếu cần sử dụng thêm middleware khác thì viết tiếp thế nào?

Đăng ký thêm trong Program.cs theo thứ tự mong muốn: `app.UseMiddleware<AnotherMiddleware>();`

## 6. Cấu trúc thư mục sau bài 7

```
BookManagement
│
├── Controllers
│   └── BookController.cs
│
├── Models
│   └── Book.cs
│
├── Views
│   └── Book
│       ├── Index.cshtml
│       ├── Detail.cshtml
│       └── Create.cshtml
│
├── Middlewares
│   └── RequestLoggingMiddleware.cs
│
└── Program.cs
```

## 7. Các chức năng đã thực hiện

1. **Middleware ghi log request** – ghi [Thời gian] Method: GET/POST - Path: /Book/... ra Console
2. **Ghi log status code** – ghi Status Code sau khi request xử lý xong
3. **Chặn truy cập URL không hợp lệ** – chặn /Book/Detail/0 và /Book/Detail/-1, trả về 400
4. **Gắn middleware vào pipeline** – đăng ký trong Program.cs trước MapControllerRoute
