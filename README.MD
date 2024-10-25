# Proje Veritabanı Yapısı

Bu belge, projemizde kullanılan veri modelinin yapısını ve tablolar arasındaki ilişkileri açıklamaktadır. Aşağıda yer alan tabloların sıralaması, hangi sırayla doldurulmaları gerektiğini göstermektedir.

## Tablolar ve İlişkileri

1. **User**
   - Kullanıcıları temsil eder ve diğer birçok entity ile ilişkilidir.
   - **Açıklama**: İlk önce bu tabloyu doldurmalısın, çünkü diğer tablolar bu tabloya referans içeriyor.

2. **Address**
   - `User` tablosundan bağımlıdır.
   - **Açıklama**: Kullanıcılar eklendikten sonra adres bilgilerini ekleyebilirsin.

3. **Category**
   - Ürünlerin kategorilerini temsil eder.
   - **Açıklama**: İlk başta bu tabloyu doldurmak, ürünleri eklerken kategori ilişkilendirmesi yapabilmek için faydalı olacaktır.

4. **Product**
   - Ürün bilgilerini içerir.
   - **Açıklama**: Ürünlerin kategorileri olduğu için önce `Category` tablosunu doldurduktan sonra bu tabloyu doldurmalısın.

5. **Order**
   - Siparişleri temsil eder.
   - **Açıklama**: Siparişler kullanıcıya ve adres bilgisine bağlı olduğundan önce `User` ve `Address` tablolarını doldurmalısın.

6. **OrderItem**
   - Siparişlerdeki ürünleri temsil eder.
   - **Açıklama**: Öncelikle `Order` ve `Product` tablolarını doldurduktan sonra bu tabloyu ekleyebilirsin.

7. **Payment**
   - Ödemeleri temsil eder.
   - **Açıklama**: `Order` tablosuna bağımlı olduğu için önce siparişleri doldurmalısın.

8. **Shipping**
   - Gönderim bilgilerini içerir.
   - **Açıklama**: Siparişler oluşturulduktan sonra bu tabloyu doldurmalısın.

9. **Coupon**
   - İndirim kuponları, siparişlere bağlıdır.
   - **Açıklama**: Önce `Order` tablosunu doldurman gerekir.

10. **Discount**
    - Ürünlere uygulanacak indirimleri temsil eder.
    - **Açıklama**: Öncelikle `Product` tablosunu doldurduktan sonra bu tabloyu ekleyebilirsin.

11. **Review**
    - Ürünlere yapılan yorumları içerir.
    - **Açıklama**: Kullanıcı ve ürün bilgilerine bağlı olduğu için önce `User` ve `Product` tablolarını doldurmalısın.

12. **ProductImage**
    - Ürün resimlerini temsil eder.
    - **Açıklama**: Öncelikle `Product` tablosunu doldurmalısın.

13. **Refund**
    - İadeleri temsil eder.
    - **Açıklama**: `Payment` tablosuna bağlı olduğu için önce ödemeleri doldurmalısın.

## Kullanım

Yukarıda belirtilen sırayı takip ederek tablolarınızı doldurduğunuzda, veri ilişkilerini doğru bir şekilde yönetebilir ve sisteminizin işleyişini optimize edebilirsiniz.



# Project Database Structure

This document explains the structure of the data model used in our project and the relationships between the tables. The order of the tables below indicates the sequence in which they should be populated.

## Tables and Their Relationships

```plaintext
+----------------+          +----------------+          +----------------+
|      User      |          |     Address    |          |    Category    |
+----------------+          +----------------+          +----------------+
| Id (PK)        | <------> | Id (PK)        |          | Id (PK)        |
| Name           |          | Street         |          | Name           |
| Email          |          | City           |          | ParentCategoryId|
| Password       |          | State          |          | (FK)           |
| Role           |          | ZipCode        |          |                |
|                |          | UserId (FK)    | <------> |                |
+----------------+          +----------------+          +----------------+
         |                                                       |
         |                                                       |
         |                                                       |
         |                                                       |
+----------------+          +----------------+          +----------------+
|     Order      | <------> |   OrderItem    | <------> |     Product    |
+----------------+          +----------------+          +----------------+
| Id (PK)        |          | Id (PK)        |          | Id (PK)        |
| UserId (FK)    | <------> | OrderId (FK)   |          | Name           |
| TotalPrice     |          | ProductId (FK) |          | Description    |
| Status         |          | Quantity       |          | Price          |
| ShippingAddressId (FK)    | Price          |           | Stock          |
+----------------+          +----------------+          | CategoryId (FK)|
         |                                               +----------------+
         |                                                         |
         |                                                         |
+----------------+          +----------------+          +----------------+
|    Shipping    |          |     Payment    |          |     Coupon     |
+----------------+          +----------------+          +----------------+
| Id (PK)        |          | Id (PK)        |          | Id (PK)        |
| TrackingNumber |          | Amount         |         | Code           |
| ShippedDate    |          | PaymentMethod  |          | DiscountAmount |
| ShippingMethod |          | PaymentDate    |          | ExpirationDate |
| OrderId (FK)   | <------> | OrderId (FK)   |          | OrderId (FK)   |
+----------------+          +----------------+          +----------------+
                                                            |
                                                            |
                                                            |
+----------------+          +----------------+          +----------------+
|     Discount    |          |    Review      |          |    Refund      |
+----------------+          +----------------+          +----------------+
| Id (PK)        |          | Id (PK)        |          | Id (PK)        |
| DiscountRate   |          | Comment        |          | RefundAmount   |
| StartDate      |          | Rating         |          | RefundDate     |
| EndDate        |          | UserId (FK)    |          | PaymentId (FK) |
| ProductId (FK) | <------> | ProductId (FK) |          |                |
+----------------+          +----------------+          +----------------+
                                                            |
                                                            |
+----------------+                                          |
|  ProductImage  |                                          |
+----------------+                                          |
| Id (PK)        |                                          |
| ImageUrl       |                                          |
| ProductId (FK) | <-------------------------------------+
+----------------+


# Project Database Structure

This document explains the structure of the data model used in our project and the relationships between tables. The order of the tables listed below indicates the sequence in which they should be populated.

## Tables and Relationships

1. **User**
   - Represents users and is related to many other entities.
   - **Note**: This table should be populated first as other tables reference it.

2. **Address**
   - Depends on the `User` table.
   - **Note**: You can add address details after users have been added.

3. **Category**
   - Represents product categories.
   - **Note**: It’s helpful to populate this table initially to link categories when adding products.

4. **Product**
   - Contains product information.
   - **Note**: Since products are categorized, populate the `Category` table before filling in this table.

5. **Order**
   - Represents orders.
   - **Note**: As orders depend on users and addresses, populate the `User` and `Address` tables first.

6. **OrderItem**
   - Represents items in an order.
   - **Note**: Populate the `Order` and `Product` tables before adding items to this table.

7. **Payment**
   - Represents payments.
   - **Note**: As it depends on the `Order` table, populate the orders first.

8. **Shipping**
   - Contains shipping information.
   - **Note**: This table should be filled in after the orders are created.

9. **Coupon**
   - Represents discount coupons, related to orders.
   - **Note**: You must populate the `Order` table first.

10. **Discount**
    - Represents discounts applied to products.
    - **Note**: Populate the `Product` table before adding entries to this table.

11. **Review**
    - Contains product reviews.
    - **Note**: Since it depends on users and products, populate the `User` and `Product` tables first.

12. **ProductImage**
    - Represents product images.
    - **Note**: Populate the `Product` table first.

13. **Refund**
    - Represents refunds.
    - **Note**: As it depends on the `Payment` table, populate payments first.

## Usage

By following the order listed above to populate your tables, you can manage data relationships properly and optimize the functioning of your system.
