##### 对微服务应用的实践与研究

##### 项目还在更新中

##### 目前完成进度：10%

##### 分层说明

- Infrastructure（基础设施层）
  - 包含公共库（通用枚举、通用特性类、通用工具类等）
  - 包含抽象数据请求对象（通用抽象实体模型、通用DBContext等）
  - 其它底层设施（如redis帮助库等）

- Domain（领域模型层）
  - 包含各领域模型（如授权领域模型）

- Application（应用层，使用Grpc作为底层通讯库）
  - 微服务集群客户端
  - 微服务集群服务端

- Presentation（表现层）
  - WebApi或其它对外应用
