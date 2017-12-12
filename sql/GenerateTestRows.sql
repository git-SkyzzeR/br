create table t1000 (num int not null)
go
declare @i int
set @i = 0
while @i < 1000
begin
	insert t1000 values(@i)
	set @i = @i + 1
end
go
--truncate table Book
insert Book (Title, Pages, Author)
select 'Test' + cast(id as varchar(10)), num,
	case when num = 1 then 'Test Author' end
from (
	select t1.num * 1000 * t2.num as id, t1.num from 
		t1000 t1 cross join t1000 t2
) t
go