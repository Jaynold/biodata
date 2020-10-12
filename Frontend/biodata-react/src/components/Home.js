import React, { useState, useEffect } from "react";
import Filter from "./Filter";
import CountFilters from "./CountFilters";
import Search from "antd/lib/input/Search";
import { debounce } from "lodash";
import { useBioData } from "../hooks/useBioData";
import { Card, Badge, Pagination, Spin, Tag } from "antd";
import Meta from "antd/lib/card/Meta";
import {
  AndroidOutlined,
  WindowsOutlined,
  MacCommandOutlined,
} from "@ant-design/icons";

const Home = () => {
  const [filteredData, setFilteredData] = useState(false);
  const [searchTerm, setSearchTerm] = useState(false);
  const [biodata, setConfig] = useBioData(false);
  const [paginationRange, setPaginationRange] = useState(false);
  const maxPerPage = 12;

  useEffect(() => {
    setConfig({ url: "", method: "get" });
  }, [setConfig]);

  useEffect(
    () =>
      setPaginationRange({
        minValue: 0,
        maxValue: maxPerPage,
      }),
    [biodata, filteredData]
  );

  return (
    <>
      <h1 id="heading">BioData</h1>
      <Filter
        layout="row"
        onFiltered={setFilteredData}
        setSearchTerm={setSearchTerm}
        datasource={biodata}
        render={(_, onSearch) => {
          return (
            <Search
              className="search"
              placeholder="Search By Name"
              onSearch={value =>
                debounce(onSearch, 250, { maxWait: 1000 })("name", value)
              }
              enterButton
            />
          );
        }}
      />

      <section className="biodata-section">
        <CountFilters
          datasource={biodata}
          setFiltered={setFilteredData}
          setSearchTerm={setSearchTerm}
        />

        <article className="biodata-cards-section">
          <div className="tags" style={{ gridColumn: "span 4" }}>
            <Tag color="geekblue" closable>
              {searchTerm}
            </Tag>
          </div>
          {!biodata ? (
            <Spin
              style={{
                gridColumn: "span 2 / 4",
                gridRow: 2,
              }}
            />
          ) : (
            (filteredData || biodata)
              .slice(paginationRange.minValue, paginationRange.maxValue)
              .map(m => {
                return (
                  <Card
                    style={{ width: 350 }}
                    hoverable
                    cover={
                      <img
                        alt="example"
                        src="https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png"
                      />
                    }
                    key={m.id}
                    onClick={value => console.log({ m })}
                  >
                    <Meta
                      title={`${m.name} - By ${m.owner}`}
                      description={
                        <Badge
                          count={"VIB"}
                          className="site-badge-count-109"
                          style={{ backgroundColor: "#52c41a" }}
                        />
                      }
                    />
                    <br />
                    {m.operatingSystems.length > 0
                      ? m.operatingSystems.map(os => {
                          let osname = os.name.toLowerCase();
                          switch (osname) {
                            case "mac":
                              return (
                                <MacCommandOutlined
                                  style={{ fontSize: "1.5rem", color: "grey" }}
                                />
                              );
                            case "linux":
                              return (
                                <AndroidOutlined
                                  style={{
                                    fontSize: "1.5rem",
                                    color: "crimson",
                                  }}
                                />
                              );
                            case "windows":
                              return (
                                <WindowsOutlined
                                  style={{ fontSize: "1.5rem", color: "#08c" }}
                                />
                              );
                            default:
                              return null;
                          }
                        })
                      : "No Operating Systems found"}
                  </Card>
                );
              })
          )}
          <Pagination
            style={{
              gridColumn: "span 4",
            }}
            defaultCurrent={1}
            onChange={value => {
              setPaginationRange({
                minValue: (value - 1) * maxPerPage,
                maxValue: value * maxPerPage,
              });
            }}
            total={filteredData.length || biodata.length}
            defaultPageSize={maxPerPage}
          />
        </article>
      </section>
    </>
  );
};

export default Home;
