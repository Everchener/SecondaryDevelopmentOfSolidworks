inL1 = 5;inL2 = 4;inL3 = 1;
% %建立机器人模型
%        theta    d        a        alpha     offset
L1=Link([pi/2     0       0       -pi/2     0     ]); %定义连杆的D-H参数
L2=Link([-pi/2    inL1    0      pi/2        0     ]);
L3=Link([0        0       0       -pi/2     0     ]);
L4=Link([0        inL2   0         pi/2     0     ]);
L5=Link([0        0        0        -pi/2     0     ]);
L6=Link([0        inL3       0        0         0     ]);
robot=SerialLink([L1 L2 L3 L4 L5 L6],'name','ok'); %连接连杆，机器人取名ok
sumLen = inL1 + inL2 + inL3;
T = cat(2,trotx(0),trotx(90),trotx(-90),trotx(180),...
          troty(90),troty(-90),...
          trotx(45)*troty(45),trotx(-45)*troty(45),trotx(-45)*troty(-45),trotx(45)*troty(-45),...
          trotx(135)*troty(45),trotx(-135)*troty(45),trotx(-135)*troty(-45),trotx(135)*troty(-45));
Tlen = 14;
%T = cat(2,trotx(180),trotx(0),...
%         trotx(45)*troty(45),trotx(-45)*troty(45),trotx(-45)*troty(-45),trotx(45)*troty(-45),...
%         trotx(135)*troty(45),trotx(-135)*troty(45),trotx(-135)*troty(-45),trotx(135)*troty(-45));
%T = trotx(randi([0,360]))*troty(randi([0,360]));
%for i = 1:1:9
%    T = cat(2,T,trotx(randi([0,360]))*troty(randi([0,360])));
%end
armLenSqr = power(sumLen,2);
armSub = inL1 - inL2 - inL3;
global Posture;
Posture = 0;
posLen = 0;
for x = 0:sumLen/4:sumLen
    for y = sumLen/4:sumLen/4:sumLen
        for z = -sumLen:sumLen/4:sumLen
            % label = label + 1;
            pointLenSqr = power(x,2)+power(y,2)+power(z,2);
            if  armLenSqr <= pointLenSqr || armSub >= sqrt (pointLenSqr)
                continue;
            end
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
label = 0;
Arr = zeros(1,posLen);
standard = 5;
tic
for m = 1:1:posLen
    label = label + 1;
    thisT = Posture(:,:,m);
    for n = 1:1:Tlen
        if Arr(label) >= standard
            break;
        end
        if n - Arr(label) > Tlen - standard
            break;
        end
        p = robot.ikine(thisT(:,4*n-3:4*n));
        if p~=zeros
            Arr(label) = Arr(label) + 1;
        end
    end
end
toc
S1 = sum(Arr>=standard)
S2 = sum(Arr==0)

