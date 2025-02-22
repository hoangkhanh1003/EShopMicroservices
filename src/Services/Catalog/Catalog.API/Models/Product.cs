namespace Catalog.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        /// <summary>
        /// public string Name { get; set; } = default!;
        /// => Đây là một thuộc tính công khai có kiểu dữ liệu là string. Thuộc tính này cũng có cả phương thức get và set. Giá trị mặc định của thuộc tính này được khởi tạo là default!, tức là null nhưng với dấu ! để bỏ qua cảnh báo về việc gán giá trị null cho kiểu dữ liệu không nullable.
        /// </summary>
        public string Name { get; set; } = default!;
        /// <summary>
        /// public List<string> Category { get; set; } = new List<string>();
        /// => Đây là một thuộc tính công khai có kiểu dữ liệu là List<string>, tức là một danh sách các chuỗi. Thuộc tính này được khởi tạo với một đối tượng List<string> mới, nghĩa là khi đối tượng của lớp này được tạo, Category sẽ là một danh sách rỗng.
        /// </summary>
        public List<string> Category { get; set; } = new List<string>();
        public string Description { get; set; } = default!;
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}
