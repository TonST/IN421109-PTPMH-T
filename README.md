# IN4211 midterm: EduHub

Solution .NET cho đề giữa kỳ IN4211, gồm Domain, Application, Infrastructure, API và xUnit Tests. API quản lý sự kiện câu lạc bộ, dùng repository trong bộ nhớ và chọn kênh thông báo Email/SMS bằng factory.

## Chạy trong Visual Studio

1. Mở `EduHub.slnx` bằng Visual Studio 2022/2026.
2. Trong Solution Explorer, nhấp phải project `EduHub.API` và chọn **Set as Startup Project** (mở chế độ Solution, không phải Folder View).
3. Chọn profile `https` hoặc `http`, rồi nhấn **F5** hoặc **Ctrl+F5**.
4. Swagger mở tại `https://localhost:7008/swagger` hoặc `http://localhost:5161/swagger`.

Swagger có giao diện EduHub riêng. Các request mẫu cũng có trong `EduHub.API/EduHub.API.http`.

## Chạy kiểm thử

Từ thư mục gốc solution:

```powershell
dotnet test EduHub.slnx
```

## API

| Method | Route | Kết quả |
| --- | --- | --- |
| GET | `/api/clubs/{clubId}/events` | `200 OK` |
| GET | `/api/events/{id}` | `200 OK`, hoặc `404 Not Found` |
| POST | `/api/clubs/{clubId}/events` | `201 Created`, hoặc `400 Bad Request` |
| DELETE | `/api/events/{id}` | `204 No Content`, hoặc `404 Not Found` |

Repository là singleton trong bộ nhớ; dữ liệu được chia sẻ giữa các request nhưng mất khi khởi động lại ứng dụng.

## Nội dung nộp

- `TRA-LOI.md`: câu trả lời lý thuyết và sơ đồ Mermaid.
- `MinhChung/`: ảnh gọi API thành công và ảnh lỗi từ Swagger.
- `.gitignore`: loại `bin/`, `obj/` và file cá nhân khỏi Git.

Bài đang làm trên nhánh `midterm/0024417563`. Trước khi nộp, push nhánh này lên kho GitHub Public và tạo Pull Request vào `main` theo hướng dẫn của đề.
