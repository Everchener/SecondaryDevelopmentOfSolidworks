function popu = selePopu(Parent)
    %锦标赛选择法（随便选两个标签，看谁的amt比较好就选谁）
    n = numel(Parent);
    index = randperm(n);
    p1 = Parent(index(1));
    p2 = Parent(index(2));
    if p1.amt <= p1.amt
        popu = p1;
    else
        popu = p2;
    end
end