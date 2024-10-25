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

