# Đồ án môn Cơ sở dữ liệu phân tán(CSDLPT) - Đề tài Quản Lý Điểm Sinh Viên
## Yêu cầu
Giả sử  trường có 2 khoa chính : công nghệ thông tin (CNTT),  và viễn thông (VT)
Phân tán cơ sở dữ liệu QLDSV ra làm 3 mảnh với điều kiện sau: 
QLDSV được đặt trên server1: chứa thông tin của các sinh viên thuộc khoa công nghệ thông tin
QLDSV được đặt trên server2:  chứa thông tin của các sinh viên thuộc khoa viễn thông.
QLDSV được đặt trên server3:  chứa thông tin đóng học phí của các sinh viên của trường
Viết chương trình thực hiện các công việc sau trên từng khoa:
### 1. Nhập liệu: gồm các công việc sau
- Nhập danh mục lớp: Form có các chức năng sau Thêm, Xóa,  Ghi, Phục hồi. Trên từng khoa ta chỉ thấy được danh sách lớp thuộc khoa đó.
- Nhập danh sách sinh viên: dưới dạng SubForm 
Form có các chức năng sau Thêm, Xóa, Ghi, Phục hồi, Chuyển lớp. Trên từng lớp ta chỉ thấy được danh sách sinh viên thuộc lớp đó.
- Nhập môn học : trên form Nhập môn học có các nút lệnh : Thêm, Xóa,  Phục hồi, Ghi, Thoát.
- Nhập điểm:  Điểm thuộc khoa nào thì khoa đó nhập hoặc PGV nhập
Sau khi nhập xong các thông tin cần thiết (lớp, môn học, lần thi) , user click nút ‘Bắt đầu’ thì sẽ xuất hiện thêm 1 bảng có các cột:
MASV 	Họ & Tên		Điểm
Trong đó, 2 cột mã sinh viên , họ tên là đã có sẵn giá trị, ta chỉ việc nhập điểm trên bảng. Sau khi nhập điểm thi xong, click nút lệnh ‘Ghi điểm’ thì mới ghi hết điểm về CSDL. 
- Đóng học phí: login thuộc nhóm PkeToan mới được quyền vào module này.
User nhập vào mã SV, chương trình tự động load lên họ tên, mã lớp và 1 bảng chứa toàn bộ thông tin đóng học phí của sinh viên: Niên khóa, Học kỳ, Học phí, Số tiền đã đóng
User nhập vào thông tin, sau đó click nút Ghi để ghi dữ liệu vào cơ sở dữ liệu
### 2. Phân quyền: cơ sở dữ liệu có 3 nhóm người dùng: PGV (phòng giáo vụ), Khoa, PKT (phòng kế toán)
-  Nếu login thuộc nhóm PGV thì login đó có thể đăng nhập vào bất kỳ khoa nào để cập nhật bằng cách chọn tên khoa,  và tìm dữ liệu trên phân mảnh tương ứng. Login này được tạo tài khoản cho nhóm PGV,Khoa và User. 
-  Nếu login thuộc nhóm Khoa thì ta chỉ cho phép xem dữ liệu trên khoa đó   và tìm dữ liệu trên phân mảnh tương ứng để in.  Nhóm Khoa chỉ được quyền cập nhật điểm. Nhóm Khoa chỉ được tạo tài khoản cho nhóm Khoa  .
- Nếu login thuộc nhóm PKeToan thì chỉ được quyền cập nhật dữ liệu đóng học phí của sinh viên, chỉ được tạo tài khoản mới thuộc cùng nhóm.
Chương trình cho phép ta tạo các login, password và cho login này làm việc với quyền hạn tương ứng. Căn cứ vào quyền này khi user login vào hệ thống, ta sẽ biết người đó được quyền làm việc với mảnh phân tán nào hay trên tất cả các phân mảnh. 
### 3. In ấn : gồm các mục sau:
Danh sách sinh viên: Tùy thuộc vào quyền hạn của login mà ta cho phép chọn khoa – lớp để in.  
Danh sách thi hết môn: yêu cầu tương tự như in danh sách sinh viên. User nhập vào tên lớp, tên môn học ,  Ngày thi, lần thi. Danh sách này chỉ in các sinh viên còn đi học. Chương trình sẽ in ra phiếu điểm thi có dạng sau:\
DANH SÁCH THI  HẾT MÔN\
	Lớp :  xxxxxxxxxxxxxxxxxxxx\
	Môn học : xxxxxxxxxxxxxxxxx\
	Ngày thi: dd/mm/yyyy

|  STT |  Mã SV |  Họ và tên | Số tờ  |  Điểm | Chữ ký |
|---|---|---|---|---|---|
|   |   |   |   |   |   |

- Bảng điểm môn học: yêu cầu tương tự như in danh sách sinh viên. Bảng điểm môn học của 1 lớp dựa vào : tên lớp, tên môn học, lần thi. Trong đó, tên lớp và tên môn học cho phép user chọn từ trong danh sách tương ứng.

- Phiếu Điểm:  để in phiếu điểm cho một sinh viên dựa vào mã sinh viên do ta nhập hay chọn từ trong một danh sách.
Phiếu điểm gồm có các cột : STT, MÔN HỌC, ĐIỂM.
  Điểm là điểm Max của 2 lần thi 1 và 2 (nếu có).

- In danh sách đóng học phí của lớp: User phòng kế toán nhập vào mã lớp, niên khóa, học kỳ, chương trình sẽ in ra thông tin đóng học phí của sinh viên của niên khóa, học kỳ đó. Sinh viên nào chưa đóng cũng in ra.

| STT |	Họ và tên |	 Học phí  | Số tiền đã đóng |
|---|---|---|---|
|   |   |   |   |
Tổng số sinh viên : ###
Tổng số tiền đã đóng : #,###,##0 ( tiền chữ) 

- Bảng điểm tổng kết: Bảng điểm tổng kết của 1 lớp dựa vào tên lớp nhập vào. Điểm thi là điểm lớn nhất của 2 lần thi. (Cross-Tab)\
BẢNG ĐIỂM TỔNG KẾT\
LỚP : XXXXXXXXXXXXX

| MASV | Họ tên |	Môn học 1 |	Môn học 2 |	Môn học 3 |	Môn học 4 |	Môn học n |
|---|---|---|---|---|---|---|
|   |   |   |   |   |   |   |
## Ghi chú
Sinh viên tự kiểm tra các ràng buộc có thể có khi viết chương trình
 Lưu ý: Thực hiện việc truy vấn trên SQL Server.
   	- Chỉ làm việc với các sinh viên còn đang học.
## Yêu cầu về phần mềm
- SQL Server 2014 Enterprise trở lên
- Visual studio 2019 trở lên
- DevExpress 2019 trở lên
### Star if project useful for you
### Fork if you gonna contribute
