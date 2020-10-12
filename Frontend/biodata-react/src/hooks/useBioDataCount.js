import Axios from "axios";
import { useEffect, useState } from "react";

export const useBioDataCount = init => {
  const [countedValues, setCountedValues] = useState(init);

  useEffect(() => {
    let didCancel = false;

    const executeCountQuery = async () => {
      const propertyList = ["operatingSystems", "toolTypes"];

      propertyList.forEach(async element => {
        let countResult = await Axios.request({
          url: `?property=${element}`,
          method: "get",
          baseURL: process.env.REACT_APP_BASE_URL,
        });

        let count = countResult.data.reduce((map, val) => {
          map[val] = (map[val] || 0) + 1;
          return map;
        }, {});

        setCountedValues(cValues => {
          return [
            ...cValues,
            {
              [element]: count,
            },
          ];
        });
      });
    };

    if (!didCancel) {
      executeCountQuery();
    }

    return () => (didCancel = true);
  }, []);

  return [countedValues];
};
