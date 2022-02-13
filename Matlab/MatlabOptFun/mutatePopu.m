function olen = mutatePopu(len,nMuta,sumLen)
    %没有什么好的算法，就干脆让机械臂重新生成一个新的长度数组
    if rand(1,1) > nMuta
        len = round((sumLen/10 + 2 * sumLen/5*rand(1,2))*100)/100;
        len = [len,sumLen - len(1) - len(2)];
        olen = len;
    end
    olen = len;
end