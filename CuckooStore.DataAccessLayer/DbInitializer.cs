using CuckooStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuckooStore.DataAccessLayer
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<CuckooDBcontext>
    {
        protected override void Seed(CuckooDBcontext context)
        {
            if (context.Categories.Any())
            {
                return;
            }
            #region Add Categories

            var categories = new List<Category>()
            {
                new Category()
                {
                    CategoryName = "Nồi Cao Tần",
                    Description = "Nồi cao tần Cuckoo nấu cơm ngon hơn hẳn so với các hãng khác trên thị trường Giữ ấm cực tốt, thời gian giữ cơm nóng ấm khoảng 24h – 48h. Đặc biệt cơm không bị ướt, không bị thiu, độ ngon gần như lúc mới nấu." +
                    "Thiết kế nồi cơm điện cao tần Cuckoo rất hiện đại, sang trọng, theo đúng xu thế cuộc sống hiện đại. " +
                    "Nồi cao tần Cuckoo có rất nhiều tính năng hiện đại: Hẹn giờ nấu, hẹn giờ ủ ấm, nhiều chế độ nấu được cài sẵn, màn hình hiển thị thông tin LCD, nút bấm điều khiển dễ sử dụng.",
                },
                new Category()
                {
                    CategoryName = "Nồi Áp Suất Điện Tử",
                    Description = " Nồi áp suất điện nấu chín, làm mềm thức ăn nhanh chóng, giảm thời gian đun nấu đến 70% " +
                    "(1 món cháo với nồi thông thường cần hơn 1 tiếng đồng hồ để nấu chín mềm thì với nồi áp suất điện thời gian nấu chỉ còn 7 - 10 phút), " +
                    "tiết kiệm điện năng tới 50%. Nồi thiết kế kín và không thể mở ra trong suốt quá trình nấu " +
                    "(trừ khi người dùng xả áp) nên lượng dưỡng chất được bảo toàn gần như trọn vẹn, mang đến lượng dinh dưỡng, vitamin dồi dào cho cơ thể người dùng."
                },
                new Category()
                {
                    CategoryName = "Nồi Điện Cơ",
                    Description = "Nồi cơm điện cơ gồm nồi cơm điện nắp gài và nồi cơm điện nắp rời vốn rất quen thuộc với người dân Việt Nam nói riêng và Châu Á nói chung. Nồi được trang bị rơ-le cơ học, tự động ngắt và chuyển sang chế độ “Warm” giữ ấm khi đạt nhiệt độ nhất định. " +
                    "Ưu điểm: giá rẻ hơn so với nồi cơm điện tử, dao động từ 200.000 đ đến 1.000.000 đ, mẫu mã, dung tích, hãng sản xuất phong phú đa dạng, phù hợp với mọi yêu cầu của người sử dụng cách sử dụng đơn giản, dễ dàng chùi rửa, thời gian nấu cơm nhanh. " +
                    "Nhược điểm: chỉ có thể dùng để chế biến một số món ăn rất hạn chế ngoài cơm, không hẹn được giờ nấu, cơm dễ bị nhão, khô khi cho quá ít hay quá nhiều nước"
                },
                new Category()
                {
                    CategoryName = "Máy ép",
                    Description = "Nhằm đáp ứng nhu cầu cải thiện sức khỏe, làn da từ trái cây và rau củ quả tươi từ thiên nhiên mà vẫn giữ được Vitamin, Enzym, hương vị và màu sắc tự nhiên của trái cây và rau củ quả tươi cũng như phục vụ " +
                    "cho mục đích kinh doanh nước ép thì Thương Hiệu Kuvings đến từ Hàn Quốc chuyên sản xuất các sản phẩm nhà bếp, gia dụng nói chung đã cho ra đời những mẫu máy ép trái cây tốc độ chậm hiệu Kuvings cao cấp với công nghệ ép " +
                    "tốc độ chậm “Cold Pressed Juicing” mới nhất cho thị trường Việt Nam dựa trên nguyên tắc ép trái cây và rau củ quả trong môi trường ít không khí với dao ép không sinh nhiệt và tốc độ ép cực chậm bằng lực cưỡng bức cho ra lượng " +
                    "nước ép nguyên chất tươi nhiều gấp 2.0 lần và thơm ngon mà không bị tách nước nhanh."
                },
                new Category()
                {
                    CategoryName = "Đồ gia dụng",
                    Description = "Đồ gia dụng rất cần thiết cho mỗi gia đình, vì thế để đáp ứng nhu cầu của người dùng hiện nay, Cuckoo đã ra mắt rất" +
                    "nhiều sản phẩm đồ gia dụng ví dụ như: máy ép trái cây, máy say sinh tố, máy lọc không khí, bếp nướng,...Các sản phẩm tại Cuckoo rất đa dạng về màu sắc" +
                    "cũng như kích cỡ giúp cho khách hàng có thể thỏa sức lựa chọn và trải nghiệm các sản phẩm tuyệt vời nhất tại cửa hàng."
                },

            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            #endregion

            #region Add Product
            var products = new List<Product>()
            {
                new Product()
                {
                    ProductName = "CRP-JHT1009F",
                    Image = "CRP-JHT1009F.PNG",
                    BaoHanh = 12,
                    MauSac = "Đen",
                    Description = "Công nghệ áp suất kép của CRP-JHT1009F mang đến cho người dùng 2 chế độ nấu – " +
                    "không áp suất và áp suất cực cao. Nhờ đó, Cuckoo Twin Pressure có thể đáp ứng nhiều sở thích nấu khác nhau, " +
                    "đồng thời giữ nguyên hương vị ban đầu của thực phẩm và làm món cơm đạt đến độ ngon hoàn hảo",
                    Price = 16000000,
                    UnitPrice = 15299000,
                    Quantity = 50,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Cao Tần")),
                },
                new Product()
                {
                    ProductName = "CRP-LHTR1010FB",
                    Image = "CRP-LHTR1010FB.PNG",
                    BaoHanh = 12,
                    MauSac = "Đen",
                    Description = "Với công suất 1480W, nồi cơm điện Cuckoo 5.4L CR-3031V hoạt động mạnh, " +
                    "giúp cơm chín đều, hạt cơm tơi xốp, trắng mịn và đặc biệt không bị cháy dính dù bạn nấu nhiều.",
                    Price = 16000000,
                    UnitPrice = 15199000,
                    Quantity = 54,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Cao Tần")),
                },
                new Product()
                {
                    ProductName = "CRP-JHR1060FD",
                    Image = "CRP-JHR1060FD.PNG",
                    BaoHanh = 12,
                    MauSac = "Xám",
                    Description = "Nồi cơm điện cao tần CRP-JHR1060FD " +
                    "là mẫu nồi cơm điện cao tần cao cấp của Cuckoo với 1.8L, phù hợp cho 2-10 người ăn.",
                    Price = 16000000 ,
                    UnitPrice = 15099000,
                    Quantity = 100,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Cao Tần")),
                },
                new Product()
                {
                    ProductName = "CRP-LHTR1010FW",
                    Image = "CRP-LHTR1010FW.PNG",
                    BaoHanh = 12,
                    MauSac = "Trắng",
                    Description = "Áp suất cực cao (2atm), Chức năng nấu ăn mở, Mở nắp chuyển động an toàn 2 nấc, Nắp phụ không gỉ có thể tháo rời, " +
                    "Chức năng tiết kiệm năng lượng, Lớp phủ đen bóng Xwall, " +
                    "Lòng nồi bằng thép không gỉ eco",
                    Price = 16000000,
                    UnitPrice = 14999000,
                    Quantity = 54,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Cao Tần")),
                },
                new Product()
                {
                    ProductName = "CRP-JHTR1010FD",
                    Image = "CRP-JHTR1010FD.PNG",
                    BaoHanh = 12,
                    MauSac = "Đen",
                    Description = "Nồi cơm điện cao tần Cuckoo CRP-JHTR1010FD " +
                    "là mẫu nồi cơm điện cao tần cao cấp của Cuckoo với công nghệ áp suất kép Cuckoo Twin Pressure.",
                    Price = 17999000 ,
                    UnitPrice = 13999000,
                    Quantity = 62,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Cao Tần")),
                },
                new Product()
                {
                    ProductName = "CRP-CHXB1010FS",
                    Image = "CRP-CHXB1010FS.PNG",
                    BaoHanh = 12,
                    MauSac = "Xám",
                    Description = "Nồi cơm điện cao tần CRP-CHXB1010FS là mẫu nồi cơm điện cao tần Cuckoo tiệm cận cao cấp với dung tích 1.8L, " +
                    "phù hợp cho 2-10 người ăn.",
                    Price = 16000000,
                    UnitPrice = 13799000,
                    Quantity = 45,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Cao Tần")),
                },
                new Product()
                {
                    ProductName = "CRP-JHR0660FBM",
                    Image = "CRP-JHR0660FBM.PNG",
                    BaoHanh = 12,
                    MauSac = "Đen",
                    Description = "CRP-JHR0660FBM là mẫu nồi cơm điện cao tần cao cấp của Cuckoo với dung tích 1.08L, phù hợp từ 2-6 người ăn. " +
                    "Thiết kế vô cùng sang trọng và đẳng cấp. Các chương trình nấu hoàn hảo nhất được tích hợp.",
                    Price = 15000000,
                    UnitPrice = 13399000,
                    Quantity = 30,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Cao Tần")),
                },
                new Product()
                {
                    ProductName = "CRP-G1015M",
                    Image = "CRP-G1015M.PNG",
                    BaoHanh = 12,
                    MauSac = "Đỏ",
                    Description = "Nồi cơm áp suất điện tử Cuckoo CRP-G1015M có các chức năng là nấu cơm trắng, nấu gạo hạt dài, nấu cháo, hấp, nấu nhanh… giúp chị em nội trợ nấu ăn phong phú, thuận tiện. Bên cạnh đó, nồi còn có chức năng giữ ấm, hâm nóng ở mức nhiệt độ phù hợp, làm cơm không bị khô, " +
                    "cứng, giúp bạn luôn có cơm, thức ăn nóng hổi, thơm ngon sẵn sàng bất cứ lúc nào.",
                    Price = 6000000 ,
                    UnitPrice = 3399000,
                    Quantity = 150,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Áp Suất Điện Tử")),
                },
                new Product()
                {
                    ProductName = "CRP-G1030MP",
                    Image = "CRP-G1030MP.PNG",
                    BaoHanh = 12,
                    MauSac = "Đỏ",
                    Description = "Nồi cơm áp suất điện tử Cuckoo CRP-G1030MP là mẫu nồi cơm điện áp suất điện tử cao cấp của Cuckoo với dung tích 1.8L, phù hợp cho 2-10 người ăn. Với thiết kế tinh tế sang trọng khi kết hợp 2 màu đỏ trắng phù hợp. Chất nhưa đỏ trắng mang cảm giác sạch sẽ, hiện đại khi để trong gian bếp.",
                    Price = 5500000,
                    UnitPrice = 3499000,
                    Quantity = 40,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Áp Suất Điện Tử")),
                },
                new Product()
                {
                    ProductName = "CRP-N0680SR",
                    Image = "CRP-N0680SR.PNG",
                    BaoHanh = 12,
                    MauSac = "Đen",
                    Description = "Cuckoo CRP-N0680FR là mẫu nồi cơm điện áp suất điện tử cao cấp của Cuckoo với dung tích 1.08L, phù hợp cho 2-6 người ăn. Với thiết kế tinh tế sang trọng khi kết hợp 2 màu đỏ đen sang trọng, quý phái.",
                    Price = 4800000,
                    UnitPrice = 3899000,
                    Quantity = 54,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Áp Suất Điện Tử")),
                },
                new Product()
                {
                    ProductName = "CRP-L1053D",
                    Image = "CRP-L1053D.PNG",
                    BaoHanh = 12,
                    MauSac = "Đen",
                    Description = "Bên cạnh đó, nồi còn có chức năng giữ ấm, hâm nóng ở mức nhiệt độ phù hợp, làm cơm không bị khô, cứng, giúp bạn luôn có cơm, thức ăn nóng hổi, thơm ngon sẵn sàng bất cứ lúc nào. Nhiều chức năng nấu tự động.",
                    Price = 4850000,
                    UnitPrice = 3399000,
                    Quantity = 54,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Áp Suất Điện Tử")),
                },
                new Product()
                {
                    ProductName = "CRP-DHXB0610FB",
                    Image = "CRP-DHXB0610FB.PNG",
                    BaoHanh = 12,
                    MauSac = "Đen",
                    Description = "CRP-JHR0610FB là mẫu nồi cơm điện cao tần cao cấp của Cuckoo với dung tích 1.08L, phù hợp từ 2-6 người ăn. Thiết kế vô cùng sang trọng và đẳng cấp. Các chương trình nấu hoàn hảo nhất được tích hợp.",
                    Price = 15000000 ,
                    UnitPrice = 13399000,
                    Quantity = 54,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Cao Tần")),
                },
                new Product()
                {
                    ProductName = "CRP-HN1056F",
                    Image = "CRP-HN1056F.PNG",
                    BaoHanh = 12,
                    MauSac = "Trắng",
                    Description = "Nồi cơm điện Cuckoo CRP-HN1056F nồi cơm điện tử đa chức năng, có thể nấu cơm hoặc sử dụng như một chiếc nồi áp suất dùng để ninh, hầm các loại thực phẩm. Dung tích 1,8 lít rất phù hợp để nấu cho gia đình. Có màn hình hiển thị đơn giản, hiển thị chế độ nấu và quá trình nấu.",
                    Price = 9000000,
                    UnitPrice = 7539000,
                    Quantity = 54,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Áp Suất Điện Tử")),
                },
                new Product()
                {
                    ProductName = "CRP-EHS0320FG",
                    Image = "CRP-EHS0320FG.PNG",
                    BaoHanh = 12,
                    MauSac = "Đen",
                    Description = "Với thiết kế cực kỳ sang trọng và đẳng cấp, cùng với đó là sự cải tiến về vật liệu cấu thành nồi và các chương trình nấu hoàn hảo nhất được tích hợp, hứa hẹn sẽ mang đến cho quý khách hàng trải nghiệm hoản hảo nhất về công nghệ nấu đứng hàng đầu trên thế giới của Cuckoo.",
                    Price = 9000000 ,
                    UnitPrice = 7459000,
                    Quantity = 80,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Áp Suất Điện Tử")),
                },
                new Product()
                {
                    ProductName = "CRP-PK1000S",
                    Image = "CRP-PK1000S.PNG",
                    BaoHanh = 12,
                    MauSac = "Trắng Đỏ",
                    Description = "Nồi cơm điện Cuckoo CRP-PK1000S 1.8 lít được thiết kế theo kiểu nắp gài, khắc phục tình trạng tràn nước ra ngoài, bảo đảm an toàn tuyệt đối khi sử dụng. CRP-PK1000S thuộc loại nồi cơm áp suất điện tử với chế độ cài đặt thông minh, tiện lợi cho người dùng.",
                    Price = 5000000,
                    UnitPrice = 3799000,
                    Quantity = 40,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Áp Suất Điện Tử")),
                },
                new Product()
                {
                    ProductName = "CR-3521B",
                    Image = "CR-3521B.PNG",
                    BaoHanh = 12,
                    MauSac = "Đen",
                    Description = "Nồi cơm điện Cuckoo 6.3L CR-3521B là sản phẩm nồi cơm điện cơ dung tích lớn của hãng Cuckoo với dung tích 6,3 lít thích hợp dùng trong các bếp ăn tập thể như công ty, trường học, nhà hàng…",
                    Price = 6000000,
                    UnitPrice = 4299000,
                    Quantity = 51,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Điện Cơ")),
                },
                new Product()
                {
                    ProductName = "CR-3031N",
                    Image = "CR-3031N.PNG",
                    BaoHanh = 12,
                    MauSac = "Đen",
                    Description = "Nồi cơm điện Cuckoo 5.4L CR-3031N là sản phẩm nồi cơm điện cơ dung tích lớn của hãng Cuckoo với dung tích 5.4 lít thích hợp dùng trong các bếp ăn tập thể như công ty, trường học, nhà hàng…",
                    Price = 6000000,
                    UnitPrice = 4250000,
                    Quantity = 40,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Điện Cơ")),
                },
                new Product()
                {
                    ProductName = "CR-3031V",
                    Image = "CR-3031V.PNG",
                    BaoHanh = 12,
                    MauSac = "Xám",
                    Description = "Với công suất 1480W, nồi cơm điện Cuckoo 5.4L CR-3031V hoạt động mạnh, giúp cơm chín đều, hạt cơm tơi xốp, trắng mịn và đặc biệt không bị cháy dính dù bạn nấu nhiều.",
                    Price = 5500000 ,
                    UnitPrice = 4250000,
                    Quantity = 50,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Điện Cơ")),
                },
                new Product()
                {
                    ProductName = "CR-0821FI",
                    Image = "CR-0821FI.PNG",
                    BaoHanh = 24,
                    MauSac = "Hồng",
                    Description = "Thiết kế nồi cơm điện Cuckoo CR-0821F mâm nhiệt lớn giúp nhiệt truyền đều từ dưới, trên và quanh thân nồi, " +
                    "không những giúp hạt cơm chín đều mà còn làm cơm trở nên mềm dẻo hơn.",
                    Price = 3500000 ,
                    UnitPrice = 2700000,
                    Quantity = 54,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Điện Cơ")),
                },
                new Product()
                {
                    ProductName = "CR-1713R",
                    Image = "CR-1713R.PNG",
                    BaoHanh = 24,
                    MauSac = "Đen",
                    Description = "Nồi cơm điện cơ Cuckoo CR-1713R có vỏ ngoài được làm từ nhựa cao cấp, cách điện và cách nhiệt tốt, đảm bảo độ bền qua thời gian sử dụng.",
                    Price = 3500000,
                    UnitPrice = 2220000,
                    Quantity = 54,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Điện Cơ")),
                },
                new Product()
                {
                    ProductName = "CR-0631B",
                    Image = "CR-0631B.PNG",
                    BaoHanh = 24,
                    MauSac = "Đen Trắng",
                    Description = "Nồi cơm điện Cuckoo CR-0631B 1.0L được thiết kế màu trắng đen tạo nên nét ngộ nghĩnh và dễ thương cho nồi, góp phần làm nổi bật cho gian bếp nhà bạn. Lòng nồi Cuckoo CR-0631B 1.0L tráng men chống dính dày 2mm giúp cơm không bị cháy khét và bám dính vào nồi, vì thế việc vệ sinh nồi cơm điện Cuckoo sẽ đơn giản hơn.",
                    Price = 3100000,
                    UnitPrice = 2150000,
                    Quantity = 150,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Điện Cơ")),
                },
                new Product()
                {
                    ProductName = "CR-1032B",
                    Image = "CR-1032B.PNG",
                    BaoHanh = 12,
                    MauSac = "Đen",
                    Description = "Đến với thương hiệu nồi cơm điện CUCKOO bạn có nhiều sự lựa chọn hơn bao giờ hết về dung tích, màu sắc, kiểu dáng vô cùng đa dạng.",
                    Price = 3000000 ,
                    UnitPrice = 2120000,
                    Quantity = 54,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Điện Cơ")),
                },
                new Product()
                {
                    ProductName = "CR-0632",
                    Image = "CR-0632.PNG",
                    BaoHanh = 12,
                    MauSac = "Hồng",
                    Description = "Nồi cơm điện Cuckoo CR-0632 được thiết kế màu trắng hồng tạo nên nét ngộ nghĩnh và dễ thương cho nồi, góp phần làm nổi bật cho gian bếp nhà bạn. Lòng nồi Cuckoo CR-0632 tráng men chống dính dày 2mm giúp cơm không bị cháy khét và bám dính vào nồi, vì thế việc vệ sinh nồi cơm điện Cuckoo sẽ đơn giản hơn.",
                    Price = 2500000 ,
                    UnitPrice = 1870000,
                    Quantity = 200,
                    Category = categories.Single(c=>c.CategoryName==("Nồi Điện Cơ")),
                },

                new Product()
                {
                    ProductName = "Máy ép trái cây tốc độ chậm Kuvings CS520CB 500ml",
                    Image = "CS520CB.PNG",
                    BaoHanh = 12,
                    MauSac = "Xám",
                    Description = "Máy ép trái cây tốc độ chậm dành cho kinh doanh hiệu Kuvings CS520CB dung tích 500ml được sản xuất từ linh kiện cao cấp có độ bền cao và nhựa không chứa chất độc hại, thiết kế nhỏ gọn, nhiều màu sắc trẻ trung, sang trọng, hiện đại và an toàn luôn luôn là sự lựa chọn để kinh doanh tại nhà hàng, quán bar, khách sạn và các quán chuyên nước ép.",
                    Price = 26990000 ,
                    UnitPrice = 18199000,
                    Quantity = 30,
                    Category = categories.Single(c=>c.CategoryName==("Máy ép")),
                },
                new Product()
                {
                    ProductName = "Máy ép trái cây tốc độ chậm Kuvings CS600CB 500ml",
                    Image = "CS600CB-06-256x256.PNG",
                    BaoHanh = 12,
                    MauSac = "Xám",
                    Description = "Máy ép trái cây tốc độ chậm dành cho kinh doanh hiệu Kuvings CS600CB dung tích 500ml được sản xuất từ linh kiện cao cấp có độ bền cao và nhựa không chứa chất độc hại." +
                    "Thiết kế nhỏ gọn, nhiều màu sắc trẻ trung, sang trọng, hiện đại và an toàn luôn luôn là sự lựa chọn để kinh doanh tại nhà hàng, quán bar, khách sạn và các quán chuyên nước ép.",
                    Price = 43990000 ,
                    UnitPrice = 23699000,
                    Quantity = 30,
                    Category = categories.Single(c=>c.CategoryName==("Máy ép")),
                },
                new Product()
                {
                    ProductName = "Máy ép trái cây chậm ngang Hurom Celery & Greens Bạc",
                    Image = "CELERY-GREENS-BAC-1-256x256.PNG",
                    BaoHanh = 12,
                    MauSac = "Xám",
                    Description = "Tối ưu hóa cho Nước ép Xanh:  Được sản xuất đặc biệt để ép cần tây, cỏ lúa mì, rau lá xanh và các loại rau củ như củ cải và gừng, Máy ép chậm ngang Celery & Greens sẽ mang lại lượng nước ép tối ưu và để lại bã khô." +
                    "Nước ép không có bột giấy: Được thiết kế để tự động đẩy bã ra ngoài, Máy ép trái cây chậm ngang Celery &Greens không để lại cặn bã bên trong máy ép trái cây." +
                    "Công nghệ ép chậm: Công nghệ ép chậm được cấp bằng sáng chế của Hurom đảm bảo nước trái cây của bạn luôn tươi và ở trạng thái tự nhiên nhất.",
                    Price = 17000000 ,
                    UnitPrice = 15300000,
                    Quantity = 30,
                    Category = categories.Single(c=>c.CategoryName==("Máy ép")),
                },
                new Product()
                {
                    ProductName = "Máy ép trái cây chậm Hurom H101 Bạc",
                    Image = "H101-BAC-1-256x256.PNG",
                    BaoHanh = 12,
                    MauSac = "Bạc",
                    Description = "Khi nói đến việc tạo ra các thiết kế sản phẩm cải tiến mới, phản hồi của khách hàng là cốt lõi của dòng máy ép trái cây độc đáo của thương hiệu chúng tôi. Ở đầu danh sách, việc vệ sinh dễ dàng hơn là tính năng mong muốn nhất của khách hàng. " +
                    "Với suy nghĩ này, chúng tôi đã thay đổi hoàn toàn cơ chế ép của Hurom và quyết định thay thế các bộ lọc lỗ trước đây bằng bộ lọc có rãnh. Giờ đây, với thiết kế mới và cải tiến của máy, bạn có thể tận hưởng tất cả những lợi ích của việc ép trái cây mà không phải dọn dẹp lộn xộn.",
                    Price = 13200000 ,
                    UnitPrice = 11880000,
                    Quantity = 30,
                    Category = categories.Single(c=>c.CategoryName==("Máy ép")),
                },
                new Product()
                {
                    ProductName = "Máy ép trái cây chậm Hurom HH Elite Bạc",
                    Image = "HH-ELITE-BAC-256x256.PNG",
                    BaoHanh = 12,
                    MauSac = "Bạc",
                    Description = "Máy ép trái cây chậm HH Elite bán chạy nhất của Hurom là máy ép trái cây đã được thử nghiệm trong nhiều năm. Đạt giải iF, Red Dot, IDEA và Good Design, máy ép trái cây chậm HH Elite làm hài lòng thị giác cũng như vị giác. Máy được trang bị Công nghệ ép chậm (SST) giúp ép nhẹ nhàng, yên tĩnh và hiệu quả. Ép được nhiều loại nguyên liệu thành nước trái cây thơm ngon, sôi động và sữa hạt thuần chay.",
                    Price = 16700000 ,
                    UnitPrice = 15030000,
                    Quantity = 30,
                    Category = categories.Single(c=>c.CategoryName==("Máy ép")),
                },
                new Product()
                {
                    ProductName = "Máy ép trái cây chậm Hurom HP Hồng",
                    Image = "HP-HONG-1-256x256.PNG",
                    BaoHanh = 12,
                    MauSac = "Hồng",
                    Description = "Máy ép trái cây chậm Hurom HP (màu hồng) của Hurom tôi sẽ đáp ứng mọi nhu cầu ép trái cây cá nhân của bạn. Cho dù bạn đang làm nước cam, sữa hạnh nhân hay sorbets, máy ép trái cây chậm HP đều có thể làm được. " +
                    "Kích thước nhỏ gọn của nó đảm bảo sẽ phù hợp trên bất kỳ quầy bếp nào.",
                    Price = 12800000 ,
                    UnitPrice = 11520000,
                    Quantity = 30,
                    Category = categories.Single(c=>c.CategoryName==("Máy ép")),
                },
                new Product()
                {
                    ProductName = "Máy ép trái cây chậm Hurom H200",
                    Image = "HUROM-H200-1-256x256.PNG",
                    BaoHanh = 12,
                    MauSac = "Đen",
                    Description = "Máy ép trái cây chậm H200 mới nhất của Hurom kết hợp với bộ khoang chứa Easy Clean với phễu tự nạp liệu. Đầu vào thậm chí còn lớn hơn có thể ép những quả táo nguyên quả. Tiết kiệm thời gian chuẩn bị và vệ sinh máy. " +
                    "Đồng nghĩa là có nhiều thời gian hơn để thưởng thức nước trái cây mới ép.",
                    Price = 13600000 ,
                    UnitPrice = 12240000,
                    Quantity = 30,
                    Category = categories.Single(c=>c.CategoryName==("Máy ép")),
                },
                new Product()
                {
                    ProductName = "Máy ép trái cây tốc độ chậm Kochstar KSESJ-3000",
                    Image = "KSESJ-3000-00-256x256.PNG",
                    BaoHanh = 12,
                    MauSac = "Xám",
                    Description = "Máy ép trái cây tốc độ chậm hiệu Kochstar KSESJ-3000 dung tích 400ml được sản xuất từ linh kiện cao cấp có độ bền cao và nhựa không chứa chất độc hại" +
                    "Máy có thiết kế nhỏ gọn, nhiều màu sắc trẻ trung, sang trọng, hiện đại và an toàn luôn luôn có mặt trong mọi không gian nhà bếp." +
                    "Nhằm đáp ứng nhu cầu cải thiện sức khỏe, làn da từ trái cây và rau củ quả tươi từ thiên nhiên mà vẫn giữ được Vitamin, Enzym, hương vị và màu sắc tự nhiên của trái cây và rau củ quả tươi, Thương Hiệu Kochstar đến từ Đức đã cho ra đời những mẫu máy ép trái cây tốc độ chậm hiệu Kochstar cao cấp.",
                    Price = 8200000 ,
                    UnitPrice = 5499000,
                    Quantity = 30,
                    Category = categories.Single(c=>c.CategoryName==("Máy ép")),
                },
                new Product()
                {
                    ProductName = "Máy ép trái cây tốc độ chậm Kuvings NS-120CBM2 400ml",
                    Image = "NS-120CBM2-02-256x256.PNG",
                    BaoHanh = 12,
                    MauSac = "Xám",
                    Description = "Máy ép trái cây tốc độ chậm hiệu Kuvings NS-120CBM2 dung tích 400ml được sản xuất từ linh kiện cao cấp có độ bền cao và nhựa không chứa chất độc hại, thiết kế nhỏ gọn, nhiều màu sắc trẻ trung, sang trọng, hiện đại và an toàn luôn luôn có mặt trong mọi không gian nhà bếp." +
                    "Nhằm đáp ứng nhu cầu cải thiện sức khỏe, làn da từ trái cây và rau củ quả tươi từ thiên nhiên mà vẫn giữ được Vitamin, Enzym, hương vị và màu sắc tự nhiên của trái cây và rau củ quả tươi, Thương Hiệu Kuvings đến từ Hàn Quốc chuyên sản xuất các sản phẩm nhà bếp, gia dụng nói chung đã cho ra đời những mẫu máy ép trái cây tốc độ chậm hiệu Kuvings cao cấp.",
                    Price = 8880000 ,
                    UnitPrice = 7139000,
                    Quantity = 30,
                    Category = categories.Single(c=>c.CategoryName==("Máy ép")),
                },

                new Product()
                {
                    ProductName = "Máy nướng bánh Hamilton Beach 25451-IN",
                    Image = "1-5-1-256x256.PNG",
                    BaoHanh = 12,
                    MauSac = "Đen",
                    Description = "Máy Nướng Bánh Hamilton Beach 25451-IN được sản xuất theo công nghệ hiện đại với chất liệu cao cấp giúp bạn có được thiết bị tiện dụng và tiết kiệm thời gian nhằm nâng cao chất lượng cuộc sống." +
                    "Với công suất hoạt động lên đến 1200W giúp món ăn của bạn được nướng nhanh hơn. Bề mặt nướng được phủ lớp chống dính, dễ dàng làm sạch giúp bạn thuận tiện hơn với việc chùi rửa sản phẩm sau khi dùng.",
                    Price = 3600000 ,
                    UnitPrice = 2699000,
                    Quantity = 20,
                    Category = categories.Single(c=>c.CategoryName==("Đồ gia dụng")),
                },
                new Product()
                {
                    ProductName = "Bộ nồi áp suất Inox IH 3 trong 1 POONGNYUN VGPC2-SET (3.5L/5.5L)",
                    Image = "1-11-256x256.PNG",
                    BaoHanh = 12,
                    MauSac = "Trắng",
                    Description = "Bộ nồi áp suất cao cấp Inox từ tính hiệu PoongNyun Series Vertu G loại " +
                    "3 trong 1 (vừa làm nồi áp suất + vừa làm nồi nhà bếp + vừa làm nồi hấp), " +
                    "3 lớp nguyên khối thân & đáy dầy 2.5mm giữ và gia nhiệt nhanh hơn giúp thức ăn chín mềm cực nhanh, " +
                    "tiết kiệm thời gian và nhiên liệu với các món hầm, luộc, kho, hấp, nấu cháo, nấu cơm, nấu cơm trộn, nấu gạo lức…., " +
                    "sử dụng trên bếp gas, bếp hồng ngoại và bếp từ, thiết kế nắp kiếng chịu nhiệt chống trào, tay cầm ngắn và chống nóng, " +
                    "áp dụng công nghệ đóng mở nắp hiện đại 360º (One Touch) bằng nút vặn, chức năng khóa an toàn và khóa nắp tự động thông minh 7 chế độ, " +
                    "có chức năng điều chỉnh lượng hơi thoát ra ngoài, có ghim Inox thông van xả kèm theo sản phẩm thuận tiện sử dụng cho gia đình, màu Inox viền đen đỏ, " +
                    "gồm 06 món (1 nồi 3.5L, 1 nồi 5.5L, 1 nắp áp suất, 1 nắp kiếng, 1 xửng hấp có quai xách và 1 rế).",
                    Price = 7375000 ,
                    UnitPrice = 5900000 ,
                    Quantity = 20,
                    Category = categories.Single(c=>c.CategoryName==("Đồ gia dụng")),
                },
                new Product()
                {
                    ProductName = "Bàn nướng điện Tiger Queen SQ-1300G",
                    Image = "1-13-256x256.PNG",
                    BaoHanh = 12,
                    MauSac = "Đen",
                    Description = "Bàn nướng điện hiệu Tiger Queen phủ 3 lớp tráng men Titanium kim cương dầy 4mm chống dính, chống trầy xước, dễ chùi rửa, với 5 chức năng nấu (làm bánh kép, nướng, chiên, xào, nhúng dấm), 5 mức điều chỉnh nhiệt độ từ 65ºC – 230ºC phù hợp với nhiều loại nguyên liệu, tích hợp chân đế phụ để mỡ thừa trong thức ăn không dính lại thức ăn khi nướng, tô đựng canh/soup và rế làm ráo dầu kèm theo, nóng nhanh tiết kiệm thời gian, có chức năng ngắt nhiệt tự động để tiết kiệm điện và không tạo khói trong khi nướng." +
                    "Xuất xứ : Hàn Quốc."+
                    "Kích thước mặt bàn nướng: Chiều dài 57cm x Chiều rộng 30cm."+
                    "Công suất: 220V, 1700W",
                    Price = 3300000 ,
                    UnitPrice = 2690000 ,
                    Quantity = 20,
                    Category = categories.Single(c=>c.CategoryName==("Đồ gia dụng")),
                },
                new Product()
                {
                    ProductName = "Máy Pha Cà Phê Hamilton Beach – 48465-SAU",
                    Image = "1-256x256.PNG",
                    BaoHanh = 12,
                    MauSac = "Đen",
                    Description = "Để thêm phần thu hút, máy pha cà phê BrewStation này tạo điểm nhấn với mặt trước bằng thép không gỉ. Bạn cũng sẽ tìm thấy tất cả mọi thứ của thương hiệu nổi tiếng BrewStation®: pha cà phê chỉ bằng một tay và bình chứa cách nhiệt với tính năng sưởi để giữ cho cà phê được tươi ngon trong nhiều giờ, " +
                    "như slogan của dòng BrewStation® “Your last cup tastes as fresh as the first.™”",
                    Price = 3255000 ,
                    UnitPrice = 2439000 ,
                    Quantity = 20,
                    Category = categories.Single(c=>c.CategoryName==("Đồ gia dụng")),
                },
                new Product()
                {
                    ProductName = "Máy lọc không khí Cuckoo AC-09XH10FW nhập khẩu Hàn quốc",
                    Image = "AC-09XH10FW-0-256x256.PNG",
                    BaoHanh = 12,
                    MauSac = "Xám",
                    Description = "Máy lọc không khí thế hệ mới Cuckoo AC-09XH10FW nhập khẩu Hàn quốc, sử dụng trong phòng và ngoài trời, làm sạch không khí qua 3 giai đoạn." +
                    "Bộ lọc  thứ nhất: Bộ lọc thô." +
                    "Bộ lọc thứ hai: Bộ lọc khử mùi." +
                    "Bộ lọc thứ ba: Bộ lọc bụi mịn." +
                    "Chế độ cảm biến bụi mịn: Chế độ cảm biến PM 2.5 có chức năng loại bỏ bụi mịn." +
                    "Chế độ trẻ em: Vận hành êm ái, gió nhẹ." +
                    "Mắt năng lượng: Cho phép tiết kiệm điện năng tiêu thụ." +
                    "6 chế độ đèn LED cảnh báo chất lượng không khí",
                    Price = 12699000 ,
                    UnitPrice = 9999000,
                    Quantity = 20,
                    Category = categories.Single(c=>c.CategoryName==("Đồ gia dụng")),
                },
                new Product()
                {
                    ProductName = "Nồi chiên Không dầu Cuckoo CAF-C0510DB 2.9L",
                    Image = "CAF-C0510DB-256x256.PNG",
                    BaoHanh = 12,
                    MauSac = "Xám",
                    Description = "Với công suất 1400w nhiệt được phân bố tối ưu với luồng khí nóng cực cao lên đến 200°C làm chín thức ăn nhanh chóng." +
                    "Dung tích lòng nồi 2.9l có thể chế biến được rất nhiều món ăn cho gia đình như: khoai tây, thịt bò, đùi gà, sườn, ức gà, cá, bánh xốp…" +
                    "Lòng Nồi chiên Không dầu Cuckoo được phủ lớp chống dính dễ dàng vệ sinh sau khi nấu." +
                    "Thiết kế siêu hiện đại cùng chất liệu vỏ ngoài được làm bằng nhựa cao cấp kết hợp với công nghệ cool touch cách nhiệt chống nóng vô cùng an toàn." +
                    "Nắp Nồi chiên Không dầu Cuckoo CAF - C0510DB được thiết kế thêm tay xách linh hoạt có thể rút lên hoặc hạ xuống giúp cho việc di chuyển nồi một cách dễ dàng, tiện lợi hơn.",
                    Price = 5999000 ,
                    UnitPrice = 3799000 ,
                    Quantity = 20,
                    Category = categories.Single(c=>c.CategoryName==("Đồ gia dụng")),
                },
                new Product()
                {
                    ProductName = "Vỉ nướng điện Cuckoo CFR-311 nhập khẩu Hàn quốc",
                    Image = "Cuckoo-CFR-311-256x256.PNG",
                    BaoHanh = 12,
                    MauSac = "Xanh lá",
                    Description = "Vỉ nướng điện Cuckoo CFR-311." +
                    "Công suất: 1.000w." +
                    "Nguồnđiện: 220V , 60Hz." +
                    "Trọng lượng : 4.2kg." +
                    "Chức năng hẹn giờ." +
                    "Size: 440x293x212(mm)." +
                    "Vỉ nướng phủ men Tefalon, chống dính hiệu quả, an toàn và dễ vệ sinh." +
                    "Chế độ nhiệt 2 chiều trên và dưới(nướng hai mặt trên dưới mà không cần xoay thức ăn." +
                    "Chức năng hẹn giờ (~30 phút), thông báo đã hoàn thành quá trình nấu ăn." +
                    "Có thể tùy chỉnh độ cao của vỉ nướng." +
                    "Trang bị 3 thiết bị an toàn",
                    Price = 3520000 ,
                    UnitPrice = 2799000,
                    Quantity = 20,
                    Category = categories.Single(c=>c.CategoryName==("Đồ gia dụng")),
                },
                new Product()
                {
                    ProductName = "Bếp nướng điện Cuckoo CG-252 nhập khẩu Hàn quốc",
                    Image = "Cuckoo-CG-252-4-256x256.PNG",
                    BaoHanh = 12,
                    MauSac = "Xám",
                    Description = "Model CG-252." +
                    "Công suất: 1500w." +
                    "Điện áp : 220V / 60Hz." +
                    "Dòng sản phẩm: bếp điện." +
                    "Công dụng: Bếp điện kết hợp nướng và Lẩu." +
                    "Kiểu dáng độc đáo, thiết kế sáng tạo, tính năng ưu việt." +
                    "Sự kết hợp hoàn hảo giữa nướng và lẩu nước." +
                    "Vỉ nướng chống dính tốt, nướng không khói." +
                    "Núm điều chỉnh nhiệt độ thích hợp",
                    Price = 3550000 ,
                    UnitPrice = 3020000,
                    Quantity = 20,
                    Category = categories.Single(c=>c.CategoryName==("Đồ gia dụng")),
                },
                new Product()
                {
                    ProductName = "Nồi chiên Không dầu Klarstein 5.4L",
                    Image = "Klarstein-5.4L-256x256.PNG",
                    BaoHanh = 12,
                    MauSac = "Xám",
                    Description = "NỒI CHIÊN KHÔNG DẦU KLARSTEIN CƠ 5,4L." +
                    "Với công suất 1700w nhiệt được phân bố tối ưu với luồn khí nóng đối lưu nên thức ăn ko cần lật." +
                    "Thiết kế siêu hiện đại cùng chất liệu vỏ ngoài được làm bằng inox không gỉ kết hợp với công nghệ cool touch cách nhiệt chống nóng vô cùng an toàn." +
                    "Lòng nồi với dung tích 5,4l rất rộng, có thể thoải mái chiên đồ cho cả gia đình",
                    Price =  5800000,
                    UnitPrice = 4299000,
                    Quantity = 20,
                    Category = categories.Single(c=>c.CategoryName==("Đồ gia dụng")),
                },
                new Product()
                {
                    ProductName = "Nồi chiên không dầu Điện tử Klarstein Turbo 9L nội địa Đức",
                    Image = "Klarstein-VitAir-Turbo-Smart-R-10L.PNG",
                    BaoHanh = 12,
                    MauSac = "Đỏ",
                    Description = "Nồi chiên không dầu  Klarstein là một cuộc cách mạng nấu ăn  tương lai của  Heißluftfritteuse, với sự kết hợp đa chức năng bạn có thể nấu được rất nhiều món khác nhau chỉ trong một chiếc lò nướng ." +
                    "Nấu thịt, cá và rau trong thời gian kỷ lục chỉ tính bằng phút  với sự trợ giúp của các yếu tố làm nóng hồng ngoại halogen." +
                    "Cho dù nguyên liệu tươi hoặc thực phẩm đông lạnh, các món ăn riêng lẻ hoặc thực đơn hoàn chỉnh, mọi thứ đều  không cần làm nóng trước, rã đông và đặc biệt là không bổ sung dầu, giảm chất béo và nhẹ nhàng biến thành bữa ăn ngon miệng." +
                    "Thiết kế mang tính cách mạng và công nghệ thông gió của lò nướng không khí nóng đảm bảo phân phối nhiệt đều, trong khi nước ép nấu vẫn còn trong thiết bị.",
                    Price = 9140000,
                    UnitPrice = 5688000,
                    Quantity = 20,
                    Category = categories.Single(c=>c.CategoryName==("Đồ gia dụng")),
                }
            };
            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();

            #endregion

            #region Add User
            var users = new List<User>()
            {
                new User()
                {
                    FullName = "Lương Đình Nam",
                    Email = "nam99tc@gmail.com",
                    Image = "Nam.PNG",
                    PassWord = "nam123",
                    Address = "Nam Từ Liêm - Hà Nội",
                    Phone = "0977516941",
                    Role = Role.Admin ,
                    StatusUser = StatusUser.HoatDong ,
                },
                new User()
                {
                    FullName = "Nguyễn Thị Nụ",
                    Email = "nunguyen@gmail.com",
                    Image = "Nu.PNG",
                    PassWord = "nu123",
                    Address = "Ba Đình - Hà Nội",
                    Phone = "0977587963",
                    Role = Role.Admin ,
                    StatusUser = StatusUser.HoatDong ,
                },

                new User()
                {
                    FullName = "Bùi Phương Chi",
                    Email = "chichi@gmail.com",
                    Image = "Chi.PNG",
                    PassWord = "chi123",
                    Address = "Mễ Trì - Hà Nội",
                    Phone = "0956874113",
                    Role = Role.User ,
                    StatusUser = StatusUser.HoatDong ,
                },
                new User()
                {
                    FullName = "Nguyễn Thị Trang",
                    Email = "trang90@gmail.com",
                    Image = "Trang.PNG",
                    PassWord = "trang123",
                    Address = "Cầu Giấy - Hà Nội",
                    Phone = "0951632885",
                    Role = Role.User ,
                    StatusUser = StatusUser.HoatDong ,
                },
                new User()
                {
                    FullName = "Trần Văn Tính",
                    Email = "tinhtran@gmail.com",
                    Image = "Tinh.PNG",
                    PassWord = "tinh123",
                    Address = "Trung Hòa - Hà Nội",
                    Phone = "0966584265",
                    Role = Role.User ,
                    StatusUser = StatusUser.HoatDong ,
                },
                new User()
                {
                    FullName = "Nguyễn Đình Tới",
                    Email = "toi85@gmail.com",
                    Image = "Toi.PNG",
                    PassWord = "toi123",
                    Address = "Mễ trì - Hà Nội",
                    Phone = "0956321112",
                    Role = Role.User ,
                    StatusUser = StatusUser.HoatDong ,
                },
                new User()
                {
                    FullName = "Lê Thị Hương",
                    Email = "huong@gmail.com",
                    Image = "Huong.PNG",
                    PassWord = "huong123",
                    Address = "Cầu Giấy - Hà Nội",
                    Phone = "0942554498",
                    Role = Role.User ,
                    StatusUser = StatusUser.HoatDong ,
                },
                new User()
                {
                    FullName = "Phạm Văn Sáu",
                    Email = "vansau@gmail.com",
                    Image = "Sau.PNG",
                    PassWord = "sau123",
                    Address = "Nam Từ Liêm - Hà Nội",
                    Phone = "0388403008",
                    Role = Role.User ,
                    StatusUser = StatusUser.HoatDong ,
                },
                new User()
                {
                    FullName = "Đinh Hữu Thịnh",
                    Email = "huuthinh@gmail.com",
                    Image = "Thinh.PNG",
                    PassWord = "thinh123",
                    Address = "Trung Hòa - Hà Nội",
                    Phone = "0985861886",
                    Role = Role.User ,
                    StatusUser = StatusUser.HoatDong ,
                },
                new User()
                {
                    FullName = "Nguyễn Thị Đoan Hiền",
                    Email = "doanhien@gmail.com",
                    Image = "Hien.PNG",
                    PassWord = "hien123",
                    Address = "Mễ trì - Hà Nội",
                    Phone = "0904629579",
                    Role = Role.User ,
                    StatusUser = StatusUser.HoatDong ,
                }
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
            #endregion

            //#region Add Shipper
            //var shippers = new List<Shipper>()
            //{
            //    new Shipper()
            //    {
            //        ShipperName = "Hà Thị Thương",
            //        Address = "Nam Từ Liêm - Hà Nội",
            //        Phone = "0977516941",
            //        Price = 30000 ,
            //    },
            //    new Shipper()
            //    {
            //        ShipperName = "Trần Xuân Tính",
            //        Address = "Bắc từ liêm - Hà Nội",
            //        Phone = "0977516941",
            //        Price = 20000 ,
            //    },
            //    new Shipper()
            //    {
            //        ShipperName = "Lê Thị Nụ",
            //        Address = "Nguyễn trãi - Hà Nội",
            //        Phone = "0977516941",
            //        Price = 18000 ,
            //    },
            //};
            //shippers.ForEach(s => context.Shippers.Add(s));
            //context.SaveChanges();
            //#endregion

            #region Add PhieuNhap
            var phieunhaps = new List<BallotImport>()
            {
                new BallotImport()
                {
                    NguoiNhan = "Lương Đình Nam",
                    FromAdd = "Nam Từ Liêm - Hà Nội",
                    Kho = "abc",
                    NgayNhap = new DateTime(2020,06,30),
                },
                new BallotImport()
                {
                    NguoiNhan = "Bùi Mạnh Quang",
                    FromAdd = "Nam Từ Liêm - Hà Nội",
                    Kho = "KKH",
                    NgayNhap = new DateTime(2020,05,30),
                },
                new BallotImport()
                {
                    NguoiNhan = "Đặng việt Hoàng",
                    FromAdd = "Nam Từ Liêm - Hà Nội",
                    Kho = "NCK",
                    NgayNhap = new DateTime(2020,12,14),
                },

            };
            phieunhaps.ForEach(s => context.BallotImports.Add(s));
            context.SaveChanges();
            #endregion

            #region Add Coupon
            var coupons = new List<Coupon>()
            {
                new Coupon()
                {
                    Code = "khonggiamgia",
                    Discount = 0,
                },
                new Coupon()
                {
                    Code = "nam123nam123nam123",
                    Discount = 20,
                    Description = "Giảm giá đặc biệt của Admin"
                },
                new Coupon()
                {
                    Code = "happybirthdaytoyou",
                    Discount = 30,
                    Description = "Giảm giá sinh nhật"
                },
                new Coupon()
                {
                    Code = "happynewyear2020",
                    Discount = (decimal)10.5,
                    Description = "Giảm giá trong năm 2021"
                },
            };
            coupons.ForEach(s => context.Coupons.Add(s));
            context.SaveChanges();
            #endregion

            #region Add Order
            var orders = new List<Order>()
            {
                new Order()
                {
                   OrderDate = new DateTime(2020,06,26),
                   ToName = "NamLuong",
                   ToAddr = "Ha Noi",
                   ToPhone = "0977516941",
                   Status = Status.ChoXacNhan,
                   Coupon = coupons.Single(c=>c.Code==("nam123nam123nam123")),
                   User = users.Single(c=>c.Email==("nam99tc@gmail.com")),
                },
                new Order()
                {
                   OrderDate = new DateTime(2020,10,10),
                   ToName = "hoangloc",
                   ToAddr = "Ha Noi",
                   ToPhone = "0977516941",
                   Status = Status.DaHuy,
                   Coupon = coupons.Single(c=>c.Code==("happynewyear2020")),
                   User = users.Single(c=>c.Email==("nunguyen@gmail.com")),
                },
                new Order()
                {
                   OrderDate = new DateTime(2020,02,02),
                   ToName = "Đặng Hoàng",
                   ToAddr = "Ha Noi",
                   ToPhone = "0977516941",
                   Status = Status.DangGiao,
                   Coupon = coupons.Single(c=>c.Code==("nam123nam123nam123")),
                   User = users.Single(c=>c.Email==("nam99tc@gmail.com")),
                },
                new Order()
                {
                   OrderDate = new DateTime(2020,04,12),
                   ToName = "Quốc Việt",
                   ToAddr = "Ha Noi",
                   ToPhone = "0977516941",
                   Status = Status.DaNhan,
                   Coupon = coupons.Single(c=>c.Code==("happynewyear2020")),
                   User = users.Single(c=>c.Email==("nunguyen@gmail.com")),
                },
                new Order()
                {
                   OrderDate = new DateTime(2020,07,26),
                   ToName = "Đức Trung",
                   ToAddr = "Ha Noi",
                   ToPhone = "0977516941",
                   Status = Status.DaNhan,
                   Coupon = coupons.Single(c=>c.Code==("nam123nam123nam123")),
                   User = users.Single(c=>c.Email==("nam99tc@gmail.com")),
                },
                new Order()
                {
                   OrderDate = new DateTime(2020,08,26),
                   ToName = "Văn Tự",
                   ToAddr = "Ha Noi",
                   ToPhone = "0977516941",
                   Status = Status.DaNhan,
                   Coupon = coupons.Single(c=>c.Code==("happybirthdaytoyou")),
                   User = users.Single(c=>c.Email==("nunguyen@gmail.com")),
                },
            };
            orders.ForEach(s => context.Orders.Add(s));
            context.SaveChanges();
            #endregion

            #region Add Contact
            var contacts = new List<Contact>()
            {
                new Contact()
                {
                   Date = new DateTime(2020,01,01),
                   Name = "namdfsdfsd",
                   Email = "nunguyen@gmail.com",
                   Content = "Hello my friend"
                },
                new Contact()
                {
                   Date = new DateTime(2020,07,12),
                   Name = "dsadas",
                   Email = "nuyen@gmail.com",
                   Content = "Hello can you help me?"
                },
                new Contact()
                {
                   Date = new DateTime(2020,05,01),
                   Name = "jjkhj",
                   Email = "nunn@gmail.com",
                   Content = "I don't remember your password"
                },
            };
            contacts.ForEach(s => context.Contacts.Add(s));
            context.SaveChanges();
            #endregion

        }
    }
}