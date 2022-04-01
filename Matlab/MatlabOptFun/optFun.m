function amt = optFun(inL,Posture,Arr,posLen)
standard = 5;
label = 0;
Tlen = 14;
% %建立机器人模型
%        theta    d        a        alpha     offset
L1=Link([pi/2     0       0       -pi/2     0     ]); %定义连杆的D-H参数
L2=Link([-pi/2    0 inL(1)         pi/2        0     ]);
L3=Link([0        0       0       -pi/2     0     ]);
L4=Link([0        0 inL(2)            pi/2     0     ]);
L5=Link([0        0        0        -pi/2     0     ]);
L6=Link([0        0 inL(3)              0         0     ]);
robot=SerialLink([L1 L2 L3 L4 L5 L6]);
    for m = 1:1:posLen
    label = label + 1;
    %取位姿矩阵
    thisT = Posture(:,:,m);
    for n = 1:1:Tlen
        %检测是否已达标（因为运行ikine函数实在是太慢了，要减少对ikine的调用）
        if Arr(label) >= standard
            break;
        end
        %检测是否没有希望达标（理由如上）
        if n - Arr(label) > Tlen - standard
            break;
        end
        %算是否存在逆解
        p = robot.ikine(thisT(:,4*n-3:4*n));
        if p~=zeros
            Arr(label) = Arr(label) + 1;
        end
    end
    amt = sum(Arr>=standard);
    end
end