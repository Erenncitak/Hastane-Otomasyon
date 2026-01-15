create proc sp_hastaEkle
@HastaAd varchar(10),
@HastaSoyad varchar(10),
@HastaTC char(11),
@HastaTelefon varchar(15),
@HastaSifre varchar(10),
@HastaCinsiyet varchar(5)
as
begin
	insert into Tbl_Hastalar values(@HastaAd,@HastaSoyad,@HastaTC,@HastaTelefon,@HastaSifre,@HastaCinsiyet)
end


select * from Tbl_Hastalar where HastaTC=@hastaTC and HastaSifre=@hastaSifre

select HastaAd,HastaSoyad from Tbl_Hastalar where HastaTC=@hastaTC

select DoktorAd,DoktorSoyad from Tbl_Doktorlar

select * from Tbl_Hastalar where HastaTC=@HastaTC

select HastaTC,HastaAd,HastaSoyad from Tbl_Hastalar where Hastaid=@id

select SekreterTC,SekreterSifre from Tbl_Sekreter

select SekreterAdSoyad from Tbl_Sekreter where SekreterTC=55555555555

select * from Tbl_Branslar

select BransAd from Tbl_Branslar

select * from Tbl_Doktorlar

select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@d1

select * from Tbl_Duyurular

insert into Tbl_Duyurular (Duyuru) values @d1

select * from Tbl_Doktorlar
select DoktorAd,DoktorSoyad,DoktorBrans,DoktorSifre from Tbl_Doktorlar 


insert into Tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@d1,@d2,@d3,@d4,@d5)

insert into Tbl_Doktorlar values (@d1,@d2,@d3,@d4,@d5)

select BransAd from Tbl_Branslar

select DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre from Tbl_Doktorlar

delete from Tbl_Doktorlar where DoktorTC=@d1

update Tbl_Doktorlar set DoktorAd=@d1,DoktorSoyad=@d2, DoktorBrans=@d3,DoktorSifre=@d5 where DoktorTC=@d4

select * from Tbl_Branslar

insert into Tbl_Branslar (BransAd) values @d1

delete from Tbl_Branslar where Bransid=@d1

update Tbl_Branslar set BransAd=@d1 where Bransid=@d2

select DoktorTC,DoktorSifre from Tbl_Doktorlar where DoktorTC=@d1 and DoktorSifre=@d2

select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorTC=@d1

select * from Tbl_Randevular

select * from Tbl_Duyurular

select DoktorAd,DoktorSoyad,DoktorBrans,DoktorSifre from Tbl_Doktorlar where DoktorTC=@d1

select BransAd from Tbl_Branslar

select * from Tbl_Doktorlar 

update Tbl_Doktorlar set DoktorAd=@d1, DoktorSoyad=@d2, DoktorBrans=@d3, DoktorSifre=@d5 where DoktorTC=@d4
