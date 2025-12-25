import type {SidebarsConfig} from '@docusaurus/plugin-content-docs';

const sidebars: SidebarsConfig = {
  tutorialSidebar: [
    {type: 'doc', id: 'intro'},
    {type: 'doc', id: 'install'},
    {type: 'doc', id: 'quickstart'},
    {
      type: 'category',
      label: 'ガイド',
      items: [
        'guides/execution-flow',
        'guides/variables',
        'guides/installation-tools',
        'guides/export-assembly',
        'guides/events',
        'guides/serializable-types',
        'guides/compatibility',
      ],
    },
    {
      type: 'category',
      label: 'デバッグ / 解析',
      items: [
        'debug/dump',
        'debug/opcode',
      ],
    },
    {type: 'doc', id: 'api'},
    {type: 'doc', id: 'troubleshooting'},
    {type: 'doc', id: 'faq'},
  ],
};

export default sidebars;
