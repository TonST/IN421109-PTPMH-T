# Minh chứng Swagger

Các ảnh dưới đây ghi lại thao tác thật trên Swagger UI tại `https://localhost:7008/swagger`:

- `swagger-tao-thanh-cong.jpg`: POST sự kiện hợp lệ, phản hồi `201 Created`.
- `swagger-tao-loi.jpg`: POST với tiêu đề rỗng, phản hồi `400 Bad Request`.

Để lặp lại: chạy `EduHub.API` với profile `https` trong môi trường Development, mở Swagger, gọi endpoint POST `/api/clubs/{clubId}/events` với JSON hợp lệ hoặc tiêu đề rỗng.
