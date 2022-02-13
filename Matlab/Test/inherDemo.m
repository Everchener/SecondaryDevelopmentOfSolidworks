clc,clear
N = 50;%种群大小N
L = 20;%
pc =0.8;%变异概率Pc：对群体中的每一个个体以某一概率（变异概率）把一小部分基因改变为等位基因。
pm =0.1;%遗传概率Pm：又称交叉概率。得到种群中的优质个体后，以某一概率（遗传概率）交换他们之间的部分染色体。
g =100;%
xs =20;%
xx =0;%
f = round(rand(N,L));
for k =1:g
    for i = 1:N
        u =f (i,:);
        m = 0;
        for j =1:L
            m = u(j)*2^(j-1)+m;
        end
        x(i) = xx + m*(xs-xx)/(2^L-1);
        fit(i) = func1(x(i));
    end
    maxfit = max(fit);
    minfit = min(fit);
    rr = find(fit==maxfit);
    fbest = f(rr(1,1),:);
    xbest = x(rr(1,1));
    fit = (fit-minfit)/(maxfit-minfit);

    %轮盘赌赋值操作
    sum_fit = sum(fit);
    fitvaule  = fit./sum_fit;
    fitvaule = cumsum(fitvaule);
    ms = sort(rand(N,1));
    fiti = 1;
    newi = 1;
    while newi <= N
        if (ms(newi)) < fitvaule(fiti)
            nf(newi,:) = f(fiti,:);
            newi = newi +1;
        else
            fiti = fiti +1;
        end
    end

    %概率交差操作
    for i = 1:2:N   %选择两个优秀个体
        p = rand;
        if p <pc
            q = round(rand(1,L));
            for j =1:L
                if q(j) == 1
                    temp = nf(i+1,j);
                    nf(i+1,j) = nf(i,j);
                    nf(i,j) = temp;
                end
            end
        end
    end

    %变异操作
    i =1;
    while i <= round(N*pm)
        h = randi(N);
        for j = 1:round(L*pm)
            g = randi(L);
            nf(h,g) = ~nf(h,g);
        end
        i = i+1;
    end

    f = nf;
    f(1,:) =fbest;
    value(k) = maxfit;
end
xbest;
xx = 0:0.1:20;
y =  sin(2*xx)+cos(3*xx)+xx;
figure
plot(xx,y)
figure
plot(value)
function result = func1(x)
fit = sin(2*x)+cos(3*x)+x;
result = fit;
end