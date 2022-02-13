function [olen1,olen2,isSame] = crossFun(len1, len2)
    %定义两个数组
    olen1 = [0 0 0];
    olen2 = [0 0 0];
    %随机生成改变的id和留下的id
    changeId = randi([1,3]);
    retainId = randi([1,3]);
    %加起来等于6
    surpId = 6 - changeId - retainId;
    %相等则没有发生交叉
    if changeId == retainId
        isSame = 505;%这数字我自己定的，定啥都行
        olen1 = len1;
        olen2 = len2;
    else
        %逐个替换
        isSame = 0;
        olen1(changeId) = len2(changeId);
        olen1(retainId) = len1(retainId);
        olen1(surpId) = sum(len1) - olen1(changeId) - olen1(retainId);
        olen2(changeId) = len1(changeId);
        olen2(retainId) = len2(retainId);
        olen2(surpId) = sum(len2) - olen2(changeId) - olen2(retainId);
        %万一不小心出现负数，就别交叉了
        if olen1(surpId) <= 0 || olen2(surpId) <= 0
            isSame = 505;
            olen1 = len1;
            olen2 = len2;
        end
    end
end    