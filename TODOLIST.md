# todo list

- [ ] 体验优化
    - [x] :bug: 优化规则判断的逻辑
    - [x] :bug: 设置第一次出现的错误为立即语音播放
    - [x] :recycle: 修改 MAVLink 协议相关名称
    - [x] :bug: 考试模式下8字失败后继续通过后续点会提示考试通过
    - [x] :recycle: 模拟考试
    - [x] :recycle: "8"字绕飞练习项目结束后自动开始下一次练习
    - [x] :recycle: 删除进入中心点后开始计时逻辑？
    - [x] :recycle: 水平自旋360 练习模式犯错规则处理和考试模式一样，提示退出中心点
    - [x] :recycle: 飞行出错时错误标记点应打在出错开始的一点
    - [x] 自旋开始逻辑：开始前语音提示
    - [x] 八字开始逻辑：以出桶作为统计开始逻辑
    - [x] 自旋一周完成统计
    - [ ] 八字航向统计逻辑
    - [ ] :recycle: 增大航线绘制点的间隔，
        - [ ] :recycle: 保留航线一公里，多余部分滚动删除，1000个点
        - [ ] :bug: 航线脏数据处理，超过中心点100米不画航线
    - [ ] :recycle: 八字练习模式可以重复报错，同一种错误2秒内最多上报一次
        - [x] 八字练习模式同一种错误被纠正一秒后可以再次上报
    - [ ] :recycle: 飞行过程中出错时需要记录错误点的飞行信息
        - [x] 已记录错误点的飞行信息
        - [ ] 点击错误点展示错误数据
    - [x] :recycle: 模拟考试失败后更换颜色和提示点颜色，二者保持一致
    - [ ] :recycle: 没有飞行数据时中心点距离显示为0
    - [x] :recycle: 八字绕飞水平偏移增加底色
    - [x] :recycle: 地图OSD增加场地名称显示和实时时间显示
    - [x] :recycle: 训练必须有场地才能开始
    - [ ] 未起飞提示飞机起飞，起飞提示高度（消息类型待确认）
    - [ ] 考试前RTK状态应为可用（消息类型待确认）
    - [x] x、y、z 角速度使用平滑后的postion消息
    - [x] 一键定位飞机
    - [x] 放大缩小比例尺
        - [x] 地图比例尺
    - [ ] UI 界面仅显示驾驶员
    - [x] 训练场地和时间
    - [ ] 自由训练模式已中心点为基准
    - [ ] 语音被覆盖的问题
        - [x] :bug: 八字飞行水平偏移过大语音被后续的请进入中心点覆盖。解决：八字结束时必须在中心点内
    - [ ] 低电量15%提醒，电池闪红灯
    - [x] :bug: 场地编辑的取消按钮在未编辑场地时应为不可使用
    - [ ] :bug: 鼠标指针错乱
    - [ ] :bug: 首次加载考试参数修改页面时取消按钮和保存参数按钮
    - [ ] :recycle: 删除数据模型中未使用的预留字段
    - [ ] :bug: savedata2.dat:666 模拟考试 自旋开始异常

- [ ] 地图优化，使用24级开源地图
    - [x] :bug: 地图放大后变成空白
    - [x] :bug: 地图第一次加载是空白
- [ ] RTK状态指示，地磁检测校验，高度复位
- [x] log data等目录优化
- [x] 界面功能优化，仅支持MAVLINK串口即可
- [x] login画面，取消按钮进入主界面功能取消
    -[ ] login页面点击确认后，增加MAVLink协议检测，识别到数据后进入主界面：需要更改串口逻辑

- [ ] 产品化，制作安装包，生成相应目录
    - [ ] 安装包增加窗口驱动
- [ ] 代码混淆+license
- [ ] 保存历史飞行轨迹数据，增删改查历史飞行数据


# logic change
- [ ] 标题栏 GPS状态移动到状态栏，重连按钮删除，视角切换向右移动到设置前面
- [ ] 状态栏 X、Y、Z、航速、航向、俯仰删除
- [ ] 状态栏 系统异常、 GPS定位中、GPS已定位、RTK已定位
- [ ] 系统状态：正常、异常
- [ ] 定位状态：未定位（灰色），GPS（绿色），RTK（绿色）
 -[x] 设置页面：切换地图供应商
- [x] 云上传ICON
- [x] 进入中心点开始计时下拉框删掉
- [x] 飞行组件闪白色
- [x] 八字训练参数设置页面最大角速度
- [x] 右上角块闪白色
- [ ] 训练参数固化一个默认值
- [ ] 版本信息页面
- [ ] 地图控制栏

# logic change
- [x] 第一次出现“飞行速度过慢”后在成绩记录窗口红字提示该错误，并播放语音提示，项目结束前如果再次出现该错误只播放语音提示，不再成绩记录窗口内红字标出
- [x] timer3 会在 gmap 拖动时停止触发，需要创建新线程处理，并设置所有UI更新为委托形式
- [x] 点击开始按钮后开始计时60秒，60秒内自旋开始判定条件：
    1、60秒内进入中心点且飞机转动超过15°自动开始
    2、60秒内进入中心点且飞机转动未超过15°，则在60秒倒计时结束后自动开始
    3、60秒内未进入中心点则为进入中心点超时
- [ ] 八字绕飞自动判断左右圆为飞行起始圆（暂时不做）
- [ ] 八字飞行错误判定，重复错误以每秒一次的频率报错

# 规则确认
八字绕飞判定规则移除最大角速度
八字绕飞飞行角速度取的是绝对值，显示实际正负
八字绕飞项目进行过程中不判定最小高度和最大高度，只以八字开始时的垂直高度为参考点判定垂直偏差
八字绕飞最小高度和最大高度只在八字项目开始前做高度提示使用，飞行过程中不进行判定和提示



驾驶员考试项目:
    1、水平自旋（左右自旋均可）
    2、正八字绕飞（左右起始均可）

超视距驾驶员（机长）考试项目:
    1、水平自旋（左右自旋均可）
    2、正八字绕飞（左右起始均可）

教员考试项目:
    1、左自旋
    2、右自旋
    3、倒八字绕飞（左右起始均可）


语音播放：
1、提示性语音：飞行高度不对，请离开中心点
1、提示性语音：飞行高度不对，请离开中心点
2、错误重复语音：水平偏移过大
2、错误触发语音：水平偏移过大
2、关键性语音：飞行失败，飞行超时，进入中心点超时，考试结束

# changelist
2022-08-29
- 新的自旋一周统计逻辑
- 重写项目规则校验逻辑
- "8"字绕飞练习项目结束后自动开始下一次练习
- 自旋开始前语音提示请开始自旋
- 调整八字飞行判断代码结构
- 修复水平自旋角度值范围问题

2022-08-26
- 增加进入中心点超时提示记录
- 修复八字绕飞角速度范围显示
- 修复科目飞行过程中触发错误后部分规则失效的问题
- 自旋练习出错时提示退出中心点重新开始练习
- 调整飞行过程中犯错时记录点为起始犯错点
- 修复八字绕飞航速显示为无限制的问题

2022-08-25
- 删除训练场地后自动选择新的训练场地
- 调整画圆逻辑
- 增加场地名称显示、时间显示、微调界面
- 调整训练类型默认为驾驶员
- 修复犯规后颜色被变白的问题
- 临时更改颜色为容易识别的蓝色
- 修复地磁值未更新的问题
- 调整自旋开始判断逻辑
    1、60秒内进入中心点且飞机转动超过15°自动开始
    2、60秒内进入中心点且飞机转动未超过15°，则在60秒倒计时结束后自动开始
    3、60秒内未进入中心点则为进入中心点超时

2022-08-24
- 同步串口 MAVLink 处理修改
- 修复后台线程更新界面时卡住的问题

2022-08-23
- 修复窗体关闭时委托更新控件的异常
- 修改数据模型字段名称为Mavlink形式
- 增加新的MAVLink数据解析方式
- 恢复违规判定规则为时间判定，默认1秒

2022-08-22
- 修复地图放大后变空白的问题
- 增加训练违规时在地图防止标记点
- 优化训练方式切换逻辑，增加模拟考试时两个项目的参考范围切换
- 更新结果框高度自适应，调整其父控件背景为黑色
- 调整系统状态为枚举值
- 替换数据处理定时器为后台线程，使用委托更新控件

2022-08-19
- 恢复日志模块为统一接口
- 调整考试类型与训练项目下拉框的交互方式
- 自旋360°训练项目增加状态切换日志
- 增加语音播放模块的打断播放的功能
- 优化训练规则判断逻辑代码
- 调试窗口增加速度设定

2022-08-18
- 修正"8"字绕飞项目垂直偏差与水平偏差判定条件
- "8"字绕飞项目增加航向角偏差判定逻辑
- 调整飞行指示控件的定位方式
- 调整日志模块由NLog替换为Serilog
- 调整训练模式、自旋360°状态、"8"字绕飞状态为枚举值定义
- 调整语音播报方式由时间判定修改为状态判定
- 八字练习结束后打印练习状态
- 优化三次考试机会的判断逻辑
- 增加全局错误标志，用于记录飞行训练中飞机状态变化

2022-08-17
- 增加调试页面，实时显示详细飞行数据
- 调整自旋360°项目开始判定条件，3秒倒计时或旋转超过15°
- 调整一些注释的格式
