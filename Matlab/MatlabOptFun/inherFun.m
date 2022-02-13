clc;clear
tic
format short;
nPopu = 10;%种群初始个数
maxIter = 5;%最大迭代次数
nCrossPoss = 0.8;%交叉概率
nCross = round(nPopu * nCrossPoss / 2) * 2;%交叉个数
nMuta = 0.2;%变异概率

%初始化结构体
template.len = [];
template.amt = [];

%到时候这个地方是接收函数输入的地方
inL1 = 5;inL2 = 2;inL3 = 3;
inL = [inL1 inL2 inL3];
sumLen = sum(inL);
%方向是否可达的检测矩阵（和之后位置矩阵相乘形成位姿）
T = cat(2,trotx(0),trotx(90),trotx(-90),trotx(180),...
          troty(90),troty(-90),...
          trotx(45)*troty(45),trotx(-45)*troty(45),trotx(-45)*troty(-45),trotx(45)*troty(-45),...
          trotx(135)*troty(45),trotx(-135)*troty(45),trotx(-135)*troty(-45),trotx(135)*troty(-45));

armLenSqr = power(sumLen,2);
armSub = inL1 - inL2 - inL3;
global Posture;%储存位姿的矩阵
Posture = 0;
posLen = 0;%有多少位姿点
%四分之一个正方体的所有点（用来代替全部点）
for x = 0:sumLen/4:sumLen
    for y = sumLen/4:sumLen/4:sumLen
        for z = -sumLen:sumLen/4:sumLen
            pointLenSqr = power(x,2)+power(y,2)+power(z,2);
            %筛选条件（大于臂长和小于第三臂与两臂之差）
            if  armLenSqr <= pointLenSqr || armSub >= sqrt (pointLenSqr)
                continue;
            end
            %位姿矩阵
            Tpro = transl(x,y,z) * T;
            if Posture == 0
                Posture = Tpro;
                posLen = posLen + 1;
                continue;
            end
            Posture = cat(3,Posture,Tpro);
            posLen = posLen + 1;
        end
    end
end

%遗传算法父代初始化
Parent = repmat(template,nPopu,1);
Arr = zeros(1,posLen);

%初始化种群
Parent(1).len = inL;
Parent(1).amt = optFun(Parent(1).len,Posture,Arr,posLen);
for i = 2:nPopu
%     Parent(i).len = randi([sumLen/10,sumLen/2],1,2);%位数太多不利于计算
    %随机生成两个[sumLen/10,sumLen/2]之间的机械臂长
    Parent(i).len = round((sumLen/10 + 2 * sumLen/5*rand(1,2))*100)/100;
    %第三臂为总臂长和两臂之差
    Parent(i).len = [Parent(i).len,sumLen - Parent(i).len(1) - Parent(i).len(2)];
    %符合点的数量
    Parent(i).amt = optFun(Parent(i).len,Posture,Arr,posLen);
end

%交叉变异生成下一代
for iter = 1: maxIter
    %子代模板
    offSpring = repmat(template,nCross/2,2);
    for i = 1: nCross / 2
        %选出交叉个体
        p1 = selePopu(Parent);
        p2 = selePopu(Parent);
        %进行交叉
        [offSpring(i,1).len,offSpring(i,2).len,isSame] = crossFun(p1.len,p2.len);
        %没有交叉
        if isSame == 505
            %仍然是为了减少对ikine的调用
            offSpring(i,1).amt = p1.amt;
            offSpring(i,2).amt = p2.amt;
        end
    end
    %转置矩阵
    offSpring = offSpring(:);
    for j = 1 : nCross
        %变异
        offSpring(j).len = mutatePopu(offSpring(j).len,nMuta,sumLen);
        %判断是否发生交叉或者变异
        if offSpring(j).amt ~= 0
            continue;
        end
        %调用函数算符合点数
        offSpring(j).amt = optFun(offSpring(j).len,Posture,Arr,posLen);
    end
    %合并矩阵
    newPopu = [Parent; offSpring];
    %排序获得标签
    [~,so] = sort([newPopu.amt],'descend');
    %生成新种群
    newPopu = newPopu(so);
    %替换parent
    Parent = newPopu(1:nPopu);
    %输出
    disp(['次数：',num2str(iter),'最大值',num2str(Parent(1).amt)])
end
toc
Parent(1).len