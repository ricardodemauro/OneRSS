drop table [dbo].[Table]

CREATE TABLE [dbo].[feed]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Link] VARCHAR(200) NOT NULL, 
    [Nome] VARCHAR(50) NOT NULL
)


insert into [dbo].[feed] (link, nome) values ('http://msdn.microsoft.com/asp.net/rss.xml', 'asp.net')
insert into [dbo].[feed] (link, nome) values ('http://msdn.microsoft.com/biztalk/rss.xml', 'Biztalk')
insert into [dbo].[feed] (link, nome) values ('http://msdn.microsoft.com/data/rss.xml', 'Data Acess and Storage')
insert into [dbo].[feed] (link, nome) values ('http://msdn.microsoft.com/directx/rss.xml', 'DirectX')
insert into [dbo].[feed] (link, nome) values ('http://msdn.microsoft.com/downloads/rss.xml', 'Downloads')
insert into [dbo].[feed] (link, nome) values ('http://msdn.microsoft.com/ie/rss.xml', 'Internet Explorer')