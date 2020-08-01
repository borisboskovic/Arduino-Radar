/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     8/1/2020 2:33:49 PM                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Prijava') and o.name = 'FK_PRIJAVA_PRIJAVLJU_KORISNIK')
alter table Prijava
   drop constraint FK_PRIJAVA_PRIJAVLJU_KORISNIK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Korisnik')
            and   type = 'U')
   drop table Korisnik
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Prijava')
            and   name  = 'PrijavljujeSeKorisnik_FK'
            and   indid > 0
            and   indid < 255)
   drop index Prijava.PrijavljujeSeKorisnik_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Prijava')
            and   type = 'U')
   drop table Prijava
go

/*==============================================================*/
/* Table: Korisnik                                              */
/*==============================================================*/
create table Korisnik (
   Id                   int                  identity,
   Ime                  varchar(32)          not null,
   RFID                 varchar(32)          not null,
   Pristup              bit                  not null,
   constraint PK_KORISNIK primary key (Id)
)
go

/*==============================================================*/
/* Table: Prijava                                               */
/*==============================================================*/
create table Prijava (
   Id                   int                  identity,
   Kor_Id               int                  null,
   Vrijeme              datetime             not null,
   RFID                 varchar(32)          not null,
   Pristup              bit                  not null,
   constraint PK_PRIJAVA primary key (Id)
)
go

/*==============================================================*/
/* Index: PrijavljujeSeKorisnik_FK                              */
/*==============================================================*/




create nonclustered index PrijavljujeSeKorisnik_FK on Prijava (Kor_Id ASC)
go

alter table Prijava
   add constraint FK_PRIJAVA_PRIJAVLJU_KORISNIK foreign key (Kor_Id)
      references Korisnik (Id)
go

